using Microsoft.EntityFrameworkCore;
using PackageTrackingApp.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Domain
{
    public class PackageTrackingContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Courier> Couriers { get; set; }

        public PackageTrackingContext()
        {

        }

        public PackageTrackingContext(DbContextOptions<PackageTrackingContext> options) : base(options)
        {
        }
    }
}
