using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Keywords.Commands
{
    public class AddKeywordCommand:ICommand
    {
        public string Name { get; set; }
    }
}
