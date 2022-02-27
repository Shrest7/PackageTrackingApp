using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Commands
{
    public class CreatePackage : ICommand
    {
        public Guid SellerGuid { get; set; }
        public Guid CustomerGuid { get; set; }
        public Guid CourierGuid { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public float Length { get; set; }
        [Required]
        public float Width { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;


        public CreatePackage(Guid sellerGuid, Guid customerGuid,
            Guid courierGuid, string name, float weight, float height,
            float length, float width)
        {
            SellerGuid = sellerGuid;
            CustomerGuid = customerGuid;
            CourierGuid = courierGuid;
            Name = name;
            Weight = weight;
            Height = height;
            Length = length;
            Width = width;
        }
    }
}
