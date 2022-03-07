using Microsoft.AspNetCore.JsonPatch;
using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Core.Repositories;
using PackageTrackingApp.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly PackageTrackingContext _dbContext;

        public PackageRepository(PackageTrackingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Package package)
        {
            await _dbContext.Packages.AddAsync(package);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Package>> GetAllAsync()
            => await Task.FromResult(_dbContext.Packages.ToList()
                .OrderByDescending(x => x.SentAt));

        public async Task<Package> GetAsync(Guid guid)
            => await Task.FromResult(_dbContext.Packages.SingleOrDefault(p => p.Guid == guid));

        public async Task RemoveAsync(Guid guid)
        {
            var package = _dbContext.Packages.SingleOrDefault(p => p.Guid == guid);
            _dbContext.Packages.Remove(package);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Package package)
        {
            _dbContext.Packages.Update(package);
            await _dbContext.SaveChangesAsync();
        }
    }
}
