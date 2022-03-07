using Microsoft.AspNetCore.JsonPatch;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.Commands;
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
        Task<UserDto> GetAsync(Guid userId);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task LoginAsync(string login, string password);
        Task<Guid> RegisterAsync(string email, string login, string password,
            string confirmPassword, DateTime dateOfBirth);
        Task UpdateAsync(Guid guid, JsonPatchDocument<UpdateUser> patchDoc);
        Task DeleteAsync(Guid userId);
    }
}
