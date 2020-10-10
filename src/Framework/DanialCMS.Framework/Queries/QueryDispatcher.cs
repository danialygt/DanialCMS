using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Framework.Queries
{
    public sealed  class QueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Dispatch<T>(IQuery query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _serviceProvider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);
            return result;
        }

    }
}
