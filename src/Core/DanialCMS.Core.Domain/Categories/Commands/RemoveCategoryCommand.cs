using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Categories.Commands
{
    public class RemoveCategoryCommand:ICommand
    {
        public long Id { get; set; }
    }
}
