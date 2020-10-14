using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Commands
{
    public class EditWriterNameCommand:ICommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
