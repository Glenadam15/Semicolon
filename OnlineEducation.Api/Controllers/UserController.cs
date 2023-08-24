using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using OnlineEducation.Model;
using OnlineEducation.Repository;
using FluentValidation;
using OnlineEducation.Code.Validations;

namespace OnlineEducation.Controllers;

public class UserController : BaseController
{
    public UserController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
    {
    }
    
    [HttpPost("GetUser")]
    public dynamic GetUser([FromBody]dynamic model)
    {
        dynamic json = JObject.Parse(model.GetRawText());

        string email = json.Email;
        string password = json.Password;

        User item = repo.UserRepository
            .FindByCondition(k => k.Email == email && k.Password == password).SingleOrDefault<User>();
        if (item != null)
        {
            return new
            {
                success = true,
                data = item
            };
        }
        else
        {
            return new
            {
                success = false,
                message = "Email or password is wrong"
            };
        }
  
    }
    
    [HttpPost("SignUp")]
    public dynamic SignUp([FromBody] dynamic model)
    {
        dynamic json = JObject.Parse(model.GetRawText());

        string email = json.Email;
        string password = json.Password;

        User item = new User()
        {
            IsActive = true,
            Email = email,
            Password = password,
            RoleId = Enums.Roles.Student
        };

        User? user = repo.UserRepository.FindByCondition(k => k.Email == item.Email).SingleOrDefault<User>();
        if (user != null)
        {
            return new
            {
                success = false,
                message = "User already exists"
            };
        }
        
        UserValidator validator = new UserValidator();
        validator.ValidateAndThrow(item);
        
        repo.UserRepository.Create(item);
        repo.SaveChanges();

        return new
        {
            success = true
        };
    }
}