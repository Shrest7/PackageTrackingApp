using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.DTOs
{
    public class UserDto
    {
        public Guid Guid { get; private set; }
        public string Login { get; private set; }
        public string Role { get; private set; }
        public string Email { get; private set; }
        public string CreatedAt { get; private set; }
    }
}
