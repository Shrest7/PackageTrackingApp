using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Commands
{
    public class UpdatePackage
    {
        public Guid CourierGuid { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
    }
}
