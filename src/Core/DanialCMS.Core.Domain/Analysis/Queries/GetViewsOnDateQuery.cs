using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Analysis.Queries
{
    public class GetViewsOnDateQuery : IQuery
    {
        public DateTime Date { get; set; }
    }
}
