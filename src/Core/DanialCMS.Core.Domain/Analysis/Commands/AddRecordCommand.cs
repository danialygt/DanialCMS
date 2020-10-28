using DanialCMS.Core.Domain.Analysis.Entities;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;


namespace DanialCMS.Core.Domain.Analysis.Commands
{
    public class AddRecordCommand : ICommand
    {
        public CMSAnalysis Analysis { get; set; }
    }
}
