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
        public Guid SellerGuid { get; set; }
        public Guid CustomerGuid { get; set; }
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
