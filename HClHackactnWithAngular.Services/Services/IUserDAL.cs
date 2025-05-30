using HClHackactnWithAngular.Repositories.Entities;
using System.Reflection.Metadata;

namespace HClHackactnWithAngular.Services.Services;

public interface IUserDAL
{

    Task<List<User>> GetUsers();
    Task<bool> AddUsers(User user);
    Task<User> GetUser(int id);
}