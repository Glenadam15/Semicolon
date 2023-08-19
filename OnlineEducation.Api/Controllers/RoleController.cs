using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using OnlineEducation.Model;
using OnlineEducation.Repository;

namespace OnlineEducation.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        public RoleController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {

        }

        [HttpGet("GetAllRoles")]
        public dynamic GetAllRoles()
        {
            List<Role> items = repo.RoleRepository.FindAll().ToList<Role>();
            return new
            {
                success = true,
                data = items
            };
        }


        [HttpPost("Save")]
        public dynamic Save([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Role item = new Role()
            {
                Id = json.Id,
                Name = json.Name
            };

            if (string.IsNullOrEmpty(item.Name))
            {
                return new
                {
                    sucess = false,
                    message = "Name cannot be empty"
                };
            }

        
            if (item.Id > 0)
            {
                repo.RoleRepository.Update(item);
            }
            else
            {
                repo.RoleRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true
            };
        }

        [HttpDelete("Delete")]
        public dynamic Delete(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Invalid id"
                };
            }

            repo.RoleRepository.RoleDelete(id);
            return new
            {
                success = true
            };
        }
    }
}
