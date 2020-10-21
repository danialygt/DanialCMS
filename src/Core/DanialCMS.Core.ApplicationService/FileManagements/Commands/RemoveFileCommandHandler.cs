using DanialCMS.Core.Domain.FileManagements.Commands;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Framework.Commands;
using System;

namespace DanialCMS.Core.ApplicationService.FileManagements.Commands
{
    public class RemoveFileCommandHandler : CommandHandler<RemoveFileCommand>
    {
        private readonly IFileManagementCommandRepository _fileCommandRepository;
        private readonly IFileManagementQueryRepository _fileQueryRepository;

        public RemoveFileCommandHandler(IFileManagementCommandRepository fileManagementCommandRepository,
            IFileManagementQueryRepository fileManagementQueryRepository)
        {
            _fileCommandRepository = fileManagementCommandRepository;
            _fileQueryRepository = fileManagementQueryRepository;
        }

        public override CommandResult Handle(RemoveFileCommand command)
        {
            if (IsValid(command))
            {
                _fileCommandRepository.Delete(command.Id);
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(RemoveFileCommand command)
        {
            bool isValid = true;
            if (!_fileQueryRepository.IsExist(command.Id))
            {
                isValid = false;
                AddError("", "این فایل وجود ندارد");
            }

            return isValid;
        }
    }
}
