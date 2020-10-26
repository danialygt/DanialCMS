using DanialCMS.Core.Domain.Contents.Commands;
using DanialCMS.Core.Domain.Contents.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Contents.Commands
{
    public class EditStatusContentCommandHandler : CommandHandler<EditStatusContentCommand>
    {
        private readonly IContentCommandRepository _contentCommandRepository;

        public EditStatusContentCommandHandler(IContentCommandRepository contentCommandRepository)
        {
            _contentCommandRepository = contentCommandRepository;
        }

        public override CommandResult Handle(EditStatusContentCommand command)
        {
            try
            {
                _contentCommandRepository.EditStatus(command.Id, command.ContentStatus);
                return Ok();
            }
            catch
            {
                return Failure();
            }
        }

    }
}
