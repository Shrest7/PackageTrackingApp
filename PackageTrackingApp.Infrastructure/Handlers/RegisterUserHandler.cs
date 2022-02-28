using PackageTrackingApp.Infrastructure.Commands;
using PackageTrackingApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Handlers
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IUserService _userService;

        public RegisterUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Guid> HandleAsync(RegisterUser command)
        {
            return await _userService.RegisterAsync(command.Email, command.Login, command.Password,
                command.ConfirmPassword, command.DateOfBirth);
        }
    }
}
