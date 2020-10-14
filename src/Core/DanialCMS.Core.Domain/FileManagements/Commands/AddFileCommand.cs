using DanialCMS.Framework.Commands;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.FileManagements.Commands
{
    public class AddFileCommand:ICommand
    {
        public string FileUrl { get; set; }
        public string FileType { get; set; }

    }
}
