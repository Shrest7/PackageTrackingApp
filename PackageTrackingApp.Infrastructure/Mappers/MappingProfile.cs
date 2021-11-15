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
                    .ForMember(p => p.CustomerFirstName, c => c.MapFrom(d => d.Customer.FirstName))
                    .ForMember(p => p.CustomerLastName, c => c.MapFrom(d => d.Customer.LastName))
                    .ForMember(p => p.SellerFirstName, c => c.MapFrom(d => d.Seller.FirstName))
                    .ForMember(p => p.SellerLastName, c => c.MapFrom(d => d.Seller.LastName))
                    .ForMember(p => p.PackageCategory, c => c.MapFrom(d => d.Category.ToString()));

                cfg.CreateMap<CreatePackageDto, Package>()
                    .ForPath(p => p.Customer.FirstName, c => c.MapFrom(d => d.CustomerFirstName))
                    .ForPath(p => p.Customer.LastName, c => c.MapFrom(d => d.CustomerLastName))
                    .ForPath(p => p.Seller.FirstName, c => c.MapFrom(d => d.SellerFirstName))
                    .ForPath(p => p.Seller.LastName, c => c.MapFrom(d => d.SellerLastName));
            });

            return new Mapper(config);
        }
    }
}
