using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Categories.Commands
{
    public class AddCategoryCommand:ICommand
    {
        public string Name { get; set; }
    }
}
