using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(Guid userId);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task LoginAsync(string login, string password);
        Task<Guid> RegisterAsync(string email, string login, string password,
            string confirmPassword);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid userId);
    }
}
