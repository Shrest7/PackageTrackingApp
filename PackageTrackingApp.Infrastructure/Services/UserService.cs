using AutoMapper;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Core.Repositories;
using PackageTrackingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageTrackingApp.Core.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;
using PackageTrackingApp.Infrastructure.Commands;

namespace PackageTrackingApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task DeleteAsync(Guid userId)
        {
            var user = _userRepository.GetUserByIdAsync(userId) ??
                throw new Exception($"User with id {userId} doesn't exist.");

            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<UserDto> GetAsync(Guid userId)
            => _mapper.Map<UserDto>(await _userRepository.GetUserByIdAsync(userId));

        public async Task<IEnumerable<UserDto>> GetAllAsync()
            => _mapper.Map<IEnumerable<UserDto>>(await _userRepository.GetAllUsersAsync());

        public async Task LoginAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> RegisterAsync(string email, string login, string password,
            string confirmPassword, DateTime dateOfBirth)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if(user is not null)
            {
                throw new Exception($"Email {email} is already taken.");
            }

            user = await _userRepository.GetUserByLoginAsync(login);
            if(user is not null) 
            {
                throw new Exception($"Login {login} is already taken.");
            }

            user = new User(email, login, Roles.User, password, confirmPassword,
                dateOfBirth);

            await _userRepository.AddUserAsync(user);

            return user.Guid;
        }

        public async Task UpdateAsync(Guid guid, JsonPatchDocument<UpdateUser> patchDoc)
        {
            var user = await _userRepository.GetUserByIdAsync(guid);

            var apiModel = _mapper.Map<User, UpdateUser>(user);

            patchDoc.ApplyTo(apiModel);

            _mapper.Map(apiModel, user);

            await _userRepository.UpdateUserAsync(user);
        }
    }
}
