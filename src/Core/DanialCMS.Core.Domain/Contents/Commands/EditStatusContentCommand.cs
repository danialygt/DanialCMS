using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Commands
{
    public class EditStatusContentCommand:ICommand
    {
        public long Id { get; set; }
        public ContentStatus ContentStatus { get; set; }
    }
}
