using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.DTOs
{
    public class CreatePackageDto
    {
        public Guid SellerGuid { get; private set; }
        public Guid CustomerGuid { get; private set; }
        public string Name { get; private set; }
        public float Weight { get; private set; }
        [Required]
        public float Height { get; private set; }
        [Required]
        public float Length { get; private set; }
        [Required]
        public float Width { get; private set; }

        public CreatePackageDto(Guid sellerGuid, Guid customerGuid,
            string name, float weight, float height, float length,
            float width)
        {
            SellerGuid = sellerGuid;
            CustomerGuid = customerGuid;
            Name = name;
            Weight = weight;
            Height = height;
            Length = length;
            Width = width;
        }
    }
}
