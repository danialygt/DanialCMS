using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Analysis.Entities
{
    public class CMSAnalysis
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }


        public string IpAddress { get; set; }

        public string BrowserName { get; set; }
        public string OsName { get; set; }
        public string Path { get; set; }
        public string HttpMethod { get; set; }
        public string SatusCode { get; set; }
        public string ContentType { get; set; }
        public string Protocol { get; set; }

    }
}
