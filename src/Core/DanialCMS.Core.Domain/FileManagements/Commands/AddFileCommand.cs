using DanialCMS.Framework.Commands;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.FileManagements.Commands
{
    public class AddFileCommand:ICommand
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }

        public long FileSize { get; set; }

    }
}
