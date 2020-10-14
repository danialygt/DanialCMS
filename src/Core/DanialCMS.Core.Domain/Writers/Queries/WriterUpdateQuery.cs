using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Queries
{
    public  class WriterUpdateQuery: IQuery
    {
        public long Id { get; set; }
    }
}
