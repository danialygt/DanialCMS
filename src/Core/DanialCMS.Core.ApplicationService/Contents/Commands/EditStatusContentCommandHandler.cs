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
        private readonly IContentQueryRepository _contentQueryRepository;

        public EditStatusContentCommandHandler(IContentCommandRepository contentCommandRepository,
            IContentQueryRepository contentQueryRepository)
        {
            _contentCommandRepository = contentCommandRepository;
            _contentQueryRepository = contentQueryRepository;
        }

        public override CommandResult Handle(EditStatusContentCommand command)
        {
            if (IsValid(command))
            {
                _contentCommandRepository.EditStatus(command.Id, command.ContentStatus);
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(EditStatusContentCommand command)
        {
            bool isValid = true;
            if (!_contentQueryRepository.IsExist(command.Id))
            {
                isValid = false;
                AddError("محتوا یافت نشد");
            }

            return isValid;
        }
    }
}
