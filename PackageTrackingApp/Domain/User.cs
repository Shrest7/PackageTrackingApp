using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Core.Domains
{
    public class User
    {
        public Guid Guid { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime LastUpdated { get; protected set; }

    }
}
