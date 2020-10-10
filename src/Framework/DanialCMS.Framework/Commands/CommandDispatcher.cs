using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Framework.Commands
{
    public class CommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CommandResult Dispatch(ICommand command)
        {
            Type type = typeof(CommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _serviceProvider.GetService(handlerType);
            CommandResult result = handler.Handle((dynamic)command);
            return result;
        }
    }
}
