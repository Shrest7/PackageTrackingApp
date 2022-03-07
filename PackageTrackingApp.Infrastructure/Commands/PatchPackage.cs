using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Commands
{
    public class PatchPackage : ICommand
    {
        public string Name { get; set; }
    }
}
