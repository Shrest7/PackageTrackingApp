using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Domains
{
    public class Customer
    {
        public Guid Guid { get; set; }
        public IEnumerable<Package> PackagesOrdered { get; set; }
        public IEnumerable<Package> PackagesDelivered { get; set; }
    }
}
