﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using OnlineEducation.Model;
using OnlineEducation.Repository;

namespace OnlineEducation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    public AuthController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
    {
    }
    
    [HttpPost("Login")]
    public dynamic Login([FromBody] dynamic model)
    {
        dynamic json = JObject.Parse(model.GetRawText());

        string email = json.Email;
        string password = json.Password;

        User item = repo.UserRepository
            .FindByCondition(k => k.Email == email && k.Password == password).SingleOrDefault<User>();

        if (item != null)
        {

            Role role = repo.RoleRepository.FindByCondition(r => r.Id == item.RoleId).SingleOrDefault<Role>();

            Dictionary<string, object> claims = new Dictionary<string, object>();

            if (role!= null)
                claims.Add(ClaimTypes.Role, role.Name);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes("OnlineEducationTokenKeyForAuthentication");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature),
                Claims = claims
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new
            {
                success = true,
                data = tokenHandler.WriteToken(token),
                role = role?.Name
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
}