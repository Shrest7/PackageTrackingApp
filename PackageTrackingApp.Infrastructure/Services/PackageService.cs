using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Services
{
    public class PackageService : IPackageService
    {
        private readonly IMapper _mapper;
        private readonly PackageTrackingContext _dbContext;
        private readonly ILogger<PackageService> _logger;

        public PackageService(IMapper mapper, PackageTrackingContext dbContext,
            ILogger<PackageService> logger)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Guid> AddAsync(CreatePackageDto packageDto)
        {
            var package = _mapper.Map<CreatePackageDto, Package>(packageDto);
            package.AssignPackageToCategory();

            await _dbContext.Packages.AddAsync(package);
            _dbContext.SaveChanges();

            return package.Guid;
        }

        public async Task<PackageDto> GetAsync(Guid guid)
        {
            var package = await _dbContext.Packages.FirstOrDefaultAsync(p => p.Guid == guid);

            //if (package is null)
            //{
            //    throw new ArgumentException($"Package with id: {guid} does not exist!");
            //}

            var packageDto = _mapper.Map<Package, PackageDto>(package);

            return packageDto;
        }

        public async Task<PackageDto> GetAsync(string name)
        {
            var package = await _dbContext.Packages.Include(p => p.Customer).
                FirstOrDefaultAsync(p => p.Name == name);

            if (package is null)
            {
                throw new ArgumentException($"Package with name: {name} does not exist!");
            }

            var packageDto = _mapper.Map<Package, PackageDto>(package);

            return packageDto;
        }

        public async Task<List<PackageDto>> GetAllAsync()
        {
            var packages = await _dbContext.Packages
                .Include(p => p.Customer).
                ToListAsync();

            if (!packages.Any())
            {
                throw new ArgumentException($"There are no packages yet!");
            }

            var packagesDto = _mapper.Map<List<Package>, List<PackageDto>>(packages);

            return packagesDto;
        }

        public async Task RemoveAsync(Guid guid)
        {
            var package = await _dbContext.Packages.FirstOrDefaultAsync(p => p.Guid == guid);

            if (package is null)
            {
                throw new ArgumentException($"Package with id: {guid} doesn't exist!");
            }

            _dbContext.Packages.Remove(package);
            _dbContext.SaveChanges();
        }

        public async Task RemoveAllAsync()
        {
            _dbContext.Packages.RemoveRange(_dbContext.Packages);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid guid, Package package)
        {
            //TO DO:


            //var package = await _dbContext.Packages.FirstOrDefaultAsync(p => p.Guid == guid);

            //if (package is null)
            //{
            //    throw new ArgumentException($"Package with id: {guid} doesn't exist!");
            //}

            ////_dbContext.Update(package).
            //_dbContext.SaveChanges();
        }
    }
}
