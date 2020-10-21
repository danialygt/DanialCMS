using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.FileManagements.Commands
{
    public class RemoveFileCommand:ICommand
    {
        public long Id { get; set; }
    }
}
