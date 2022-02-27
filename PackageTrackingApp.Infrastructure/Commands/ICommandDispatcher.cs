using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
        Task<Guid> DispatchAsync<T>(T command) where T : ICommand;
    }
}
