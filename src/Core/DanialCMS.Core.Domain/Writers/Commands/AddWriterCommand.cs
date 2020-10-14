using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Dtos;

namespace DanialCMS.Core.Domain.Writers.Commands
{
    public class AddWriterCommand: ICommand
    {
        public string Name { get; set; }
        public DtoFile Photo { get; set; }
    }
}
