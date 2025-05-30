using HClHackactnWithAngular.Repositories.Data;
using HClHackactnWithAngular.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace HClHackactnWithAngular.Services
{
    public interface IUserDAL
    {
        Task<List<TblJob>> GetUsers();
        Task<bool> AddUsers();
        Task<User> GetUser(int id);
    }
    public class UserDAL: IUserDAL
    {
        public UserDAL(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TblJob>> GetUsers()
        {
            return await dBEntities.Users.ToList();
        }

        public async Task<bool> AddUsers()
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