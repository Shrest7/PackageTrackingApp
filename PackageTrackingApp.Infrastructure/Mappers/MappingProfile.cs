using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PackageTrackingApp.Core.Domain;
using PackageTrackingApp.Core.Domains;
using PackageTrackingApp.Infrastructure.Commands;
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
                    .ForMember(p => p.PackageCategory, c => c.MapFrom(d => d.Category.ToString()))
                    .ForMember(u => u.SentAt, m => m.MapFrom(x => Convert.ToString(x.SentAt, CultureInfo.InvariantCulture)));

                cfg.CreateMap<CreatePackage, Package>()
                    .AfterMap((s, d) => d.AssignPackageToCategory())
                    .ConstructUsing(x => new Package(x.CustomerGuid, x.SellerGuid, x.CourierGuid, x.Name, x.Weight,
                                                     x.Height, x.Length, x.Width));

                cfg.CreateMap<User, UserDto>()
                    .ForMember(u => u.CreatedAt, m => m.MapFrom(x => x.CreatedAt.ToString("dd-MM-yyyy")));

                cfg.CreateMap<CreateCourier, Courier>();

                cfg.CreateMap<Courier, CourierDto>()
                   .ForMember(x => x.Experience, y => y.MapFrom(z =>
                       z.DateOfEmployment != null ? 
                       (float?) DateTime.UtcNow.Subtract(z.DateOfEmployment.Value).TotalDays :
                       null
                   ));
            });

            return new Mapper(config);
        }
    }
}
