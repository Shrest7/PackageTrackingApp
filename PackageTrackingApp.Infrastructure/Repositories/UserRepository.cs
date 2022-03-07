using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PackageTrackingContext _dbContext;

        public UserRepository(PackageTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await GetUserByIdAsync(userId);

            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
            => await Task.FromResult(_dbContext.Users
                .OrderBy(x => x.Login));

        public async Task<User> GetUserByIdAsync(Guid userId)
            => await Task.FromResult(_dbContext.Users.SingleOrDefault(u => u.Guid == userId));
        public async Task<User> GetUserByEmailAsync(string email)
            => await Task.FromResult(_dbContext.Users.SingleOrDefault(u => u.Email == email));
        public async Task<User> GetUserByLoginAsync(string login)
            => await Task.FromResult(_dbContext.Users.SingleOrDefault(u => u.Login == login));
        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
