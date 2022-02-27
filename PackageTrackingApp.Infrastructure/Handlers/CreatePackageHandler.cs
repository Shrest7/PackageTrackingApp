using PackageTrackingApp.Infrastructure.Commands;
using PackageTrackingApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Handlers
{
    public class CreatePackageHandler : ICommandHandler<CreatePackage>
    {
        private readonly IPackageService _packageService;

        public CreatePackageHandler(IPackageService packageService)
        {
            _packageService = packageService;
        }

        public async Task<Guid> HandleAsync(CreatePackage command)
        {
            return await _packageService.AddAsync(command);
        }
    }
}
