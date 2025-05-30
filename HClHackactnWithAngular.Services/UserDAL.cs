using HClHackactnWithAngular.Repositories.Data;
using HClHackactnWithAngular.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace HClHackactnWithAngular.Services
{
    public interface IUserDAL
    {
        Task<List<User>> GetUsers();
        Task<bool> AddUsers(User user);
        Task<User> GetUser(int id);
    }
    public class UserDAL: IUserDAL
    {
        public readonly AppDbContext _dbContext;
        public UserDAL(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<bool> AddUsers(User user)
        {
            await _dbContext.Users.AddAsync(user);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
    }
}