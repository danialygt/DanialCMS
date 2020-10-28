using DanialCMS.Core.Domain.Analysis.Commands;
using DanialCMS.Core.Domain.Analysis.Entities;
using DanialCMS.Core.Domain.Analysis.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Analysis.Commands
{
    public class AddRecordCommandHandler : CommandHandler<AddRecordCommand>
    {
        private readonly ICMSAnalysisCommandRepository _analysisCommandRepository;

        public AddRecordCommandHandler(ICMSAnalysisCommandRepository analysisCommandRepository)
        {
            _analysisCommandRepository = analysisCommandRepository;
        }

        public override CommandResult Handle(AddRecordCommand command)
        {
            _analysisCommandRepository.Add(command.Analysis);
            return Ok();
        }
    }
}
