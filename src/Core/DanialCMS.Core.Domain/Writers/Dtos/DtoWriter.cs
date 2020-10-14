using System;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Dtos
{
    public class DtoWriter
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int CountOfContent { get; set; }

    }
}
