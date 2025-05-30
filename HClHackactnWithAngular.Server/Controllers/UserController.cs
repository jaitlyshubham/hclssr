using HClHackactnWithAngular.Repositories.Entities;
using HClHackactnWithAngular.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace HClHackactnWithAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserDAL userDAL;

        public UserController(IUserDAL userDAL)
        {
            this.userDAL= userDAL;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<User> GetUser(int id)
        {
            return await userDAL.GetUser(id);
        }

        [Route("GetList")]
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await userDAL.GetUsers();
        }

    }
}
