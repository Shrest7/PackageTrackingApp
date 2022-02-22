using PackageTrackingApp.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.DTOs
{
    public class PackageDto
    {
        public Guid Guid { get; private set; }
        public Guid CustomerGuid { get; private set; }
        public Guid SellerGuid { get; private set; }
        public string Name { get; private set; }
        public bool IsPaid { get; private set; }
        public float Weight { get; private set; }
        public float Height { get; private set; }
        public float Length { get; private set; }
        public float Width { get; private set; }
        public string PackageCategory { get; private set; }

        protected PackageDto()
        {

        }
    }
}
