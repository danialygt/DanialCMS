using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Framework.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery: IQuery
    {
        TResult Handle(TQuery query);
    }
}
