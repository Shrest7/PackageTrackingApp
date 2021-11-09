using PackageTrackingApp.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Repositories
{
    interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer Get(string email);
        List<Customer> GetAll();
        void Remove(string email);
        void Update(string email);
    }
}
