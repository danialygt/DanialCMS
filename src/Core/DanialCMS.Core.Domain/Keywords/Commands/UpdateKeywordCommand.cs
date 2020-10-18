using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Keywords.Commands
{
    public class UpdateKeywordCommand:ICommand
    {
        public long KeywordId { get; set; }
        public string Name { get; set; }
    }
}
