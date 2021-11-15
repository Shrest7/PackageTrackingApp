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
        [Required]
        [MaxLength(50)]
        public string CustomerFirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerLastName { get; set; }
        public string SellerFirstName { get; set; }
        public string SellerLastName { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        [Required]
        public float? Height { get; set; }
        [Required]
        public float? Length { get; set; }
        [Required]
        public float? Width { get; set; }
    }
}
