using PackageTrackingApp.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Repositories
{
    interface ISellerRepository
    {
        Seller Get();
        ISet<Seller> GetAll();
        void Add();
        void Remove();
        void Update();
    }
}
