using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.DTOs;

namespace PackageTrackingApp.Infrastructure.Mappers
{
    public static class MappingProfile
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Package, PackageDto>()
                    .ForMember(p => p.PackageCategory, c => c.MapFrom(d => d.Category.ToString()));

                cfg.CreateMap<CreatePackageDto, Package>()
                    .AfterMap((s, d) => d.AssignPackageToCategory());

                cfg.CreateMap<User, UserDto>()
                    .ForMember(u => u.CreatedAt, m => m.MapFrom(x => x.CreatedAt.ToString("dd-MM-yyyy")));
            });

            return new Mapper(config);
        }
    }
}
