using HClHackactnWithAngular.Repositories.Entities;
using HClHackactnWithAngular.Server.Model;
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

        [Route("Add")]
        [HttpPost]
        public async Task<bool> Add([FromBody] CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = dto.PasswordHash,
                Role = dto.Role,
                UserData = dto.UserData != null
                    ? new UserData
                    {
                        FirstName = dto.UserData.FirstName,
                        LastName = dto.UserData.LastName,
                        StaffRole = dto.UserData.StaffRole,
                        Department = dto.UserData.Department,
                        Email = dto.UserData.Email,
                        PhoneNumber = dto.UserData.PhoneNumber,
                        WeeklyShiftLimit = dto.UserData.WeeklyShiftLimit,
                        HireDate = dto.UserData.HireDate,
                        IsActive = dto.UserData.IsActive
                    }
                    : null
            };

            return await userDAL.AddUsers(user);
        }

    }
}
