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
                    .ForMember(p => p.CustomerGuid, c => c.MapFrom(d => d.Customer.Guid))
                    .ForMember(p => p.SellerGuid, c => c.MapFrom(d => d.Seller.Guid))
                    .ForMember(p => p.PackageCategory, c => c.MapFrom(d => d.Category.ToString()));

                cfg.CreateMap<CreatePackageDto, Package>()
                    .ForPath(p => p.Customer.Guid, c => c.MapFrom(d => d.CustomerGuid))
                    .ForPath(p => p.Seller.Email, c => c.MapFrom(d => d.SellerGuid))
                    .AfterMap((s, d) => d.AssignPackageToCategory());
            });

            return new Mapper(config);
        }
    }
}
