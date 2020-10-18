using DanialCMS.Core.Domain.FileManagements.Dtos;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Commands
{
    public class UpdateWriterCommand:ICommand
    {
        public long WriterId { get; set; }
        public DtoFile Photo { get; set; }
        public string Name { get; set; }
    }
}
