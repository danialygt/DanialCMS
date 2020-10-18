using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Keywords.Commands
{
    public class RemoveKeywordCommand:ICommand
    {
        public long Id { get; set; }
    }
}
