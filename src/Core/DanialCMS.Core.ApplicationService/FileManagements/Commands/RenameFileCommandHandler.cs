using DanialCMS.Core.Domain.FileManagements.Commands;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.FileManagements.Commands
{
    public class RenameFileCommandHandler : CommandHandler<RenameFileCommand>
    {
        private readonly IFileManagementCommandRepository _fileCommandRepository;
        private readonly IFileManagementQueryRepository _fileQueryRepository;

        public RenameFileCommandHandler(IFileManagementCommandRepository fileManagementCommandRepository,
            IFileManagementQueryRepository fileManagementQueryRepository)
        {
            _fileCommandRepository = fileManagementCommandRepository;
            _fileQueryRepository = fileManagementQueryRepository;
        }

        public override CommandResult Handle(RenameFileCommand command)
        {
            if (IsValid(command))
            {
                _fileCommandRepository.Rename(command.Id, command.Name);
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(RenameFileCommand command)
        {
            bool isValid = true;
            if (!_fileQueryRepository.IsExist(command.Id))
            {
                isValid = false;
                AddError("این فایل وجود ندارد");
            }
            else
            {
                if (string.IsNullOrEmpty(command.Name))
                {
                    isValid = false;
                    AddError("نام را وارد کنید");
                }
                if(command.Name.Length > 30)
                {
                    isValid = false;
                    AddError("نام نباید کمتر از 30 کاراکتر باشد");
                }
            }

            return isValid;
        }

    }
}
