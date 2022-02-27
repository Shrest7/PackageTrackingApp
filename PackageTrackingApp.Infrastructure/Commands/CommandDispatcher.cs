using Autofac;
using PackageTrackingApp.Infrastructure.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackageTrackingApp.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task<Guid> DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is null)
            {
                throw new Exception("Command can not be null.");
            }

            var handler = _context.Resolve<ICommandHandler<T>>();
            return await handler.HandleAsync(command);
        }
    }
}
