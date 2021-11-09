using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Core.Repositories;
using PackageTrackingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _repository;
        private readonly IMapper _mapper;
        private readonly PackageTrackingContext _dbContext;

        public PackageService(IPackageRepository repository, IMapper mapper,
            PackageTrackingContext dbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Add(Package package)
        {
            _repository.Add(package);
        }

        public PackageDto Get(Guid guid)
        {
            var package = _repository.Get(guid);

            if (package is null)
            {
                throw new ArgumentException($"Package with id: {guid} does not exist!");
            }

            var packageDto = _mapper.Map<Package, PackageDto>(package);

            return packageDto;
        }
        public PackageDto Get(string name)
        {
            var package = _repository.Get(name);

            if (package is null)
            {
                throw new ArgumentException($"Package with name: {name} does not exist!");
            }

            var packageDto = _mapper.Map<Package, PackageDto>(package);

            return packageDto;
        }

        public List<PackageDto> GetAll()
        {
            var testPackage = new Package(new Customer("bob", "budowniczy"),
                new Seller("mm@wp.pl", "997997997"),
                "he", 1, 2, 3, 4);
            _dbContext.Packages.Add(testPackage);
            var package = _dbContext.Packages.FirstOrDefault();
            var packages =_dbContext.Packages.ToList();

            if (!packages.Any())
            {
                throw new ArgumentException($"There are no packages yet!");
            }

            var packagesDto = _mapper.Map<List<Package>, List<PackageDto>>(packages);

            return packagesDto;
        }

        public void Remove(Guid guid)
        {
            var package = _repository.Get(guid);

            if(package is null)
            {
                throw new ArgumentException($"Package with id: {guid} doesn't exist!");
            }

            _repository.Remove(guid);
        }

        public void Update(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
