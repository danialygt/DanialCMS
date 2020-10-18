using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Categories.Commands
{
    public class UpdateCategoryCommand:ICommand
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
    }
}
