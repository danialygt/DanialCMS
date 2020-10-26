using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Queries
{
    public class GetContentQuery:IQuery
    {
        public long ContentId { get; set; }
    }
}
