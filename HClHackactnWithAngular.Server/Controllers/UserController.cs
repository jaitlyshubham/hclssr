using HClHackactnWithAngular.Services;
using Microsoft.AspNetCore.Http;
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


    }
}
