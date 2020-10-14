using DanialCMS.Core.Domain.FileManagements.Commands;
using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Framework.Commands;
using System;

namespace DanialCMS.Core.ApplicationService.FileManagements.Commands
{
    public class AddFileCommandHandler : CommandHandler<AddFileCommand>
    {
        private readonly IFileManagementCommandRepository _fileManagementCommandRepository;
        public AddFileCommandHandler(IFileManagementCommandRepository fileManagementCommandRepository)
        {
            _fileManagementCommandRepository = fileManagementCommandRepository;
        }

        public override CommandResult Handle(AddFileCommand command)
        {
            if (IsValid(command))
            {
                _fileManagementCommandRepository.Add(new FileManagement
                {
                    Url = command.FileUrl,
                    Type = command.FileType
                });
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddFileCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.FileUrl))
            {
                AddError("فایل آپلود نشده است");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(command.FileType))
            {
                AddError("نوع فایل مشکل دارد");
                isValid = false;
            }
            return isValid;
        }
    }
}
