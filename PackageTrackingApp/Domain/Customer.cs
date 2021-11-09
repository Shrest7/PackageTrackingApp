using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Domains
{
    public class Customer
    {
        [Key]
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Package> PackagesOrdered { get; set; }
        public string Email { get; protected set; }

        public Customer()
        {

        }

        public Customer(string firstName, string lastName)
        {
            Guid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
