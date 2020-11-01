using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Queries
{
    public class GetWriterIdQuery : IQuery
    {
        public string WriterName { get; set; }
    }
}
