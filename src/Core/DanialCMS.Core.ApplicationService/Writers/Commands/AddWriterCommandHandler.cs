using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Core.Domain.Writers.Commands;
using DanialCMS.Core.Domain.Writers.Entities;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.Framework.Commands;

namespace DanialCMS.Core.ApplicationService.Writers.Commands
{
    public class AddWriterCommandHandler : CommandHandler<AddWriterCommand>
    {
        private readonly IWriterCommandRepository _writerCommandRepository;
        private readonly IWriterQueryRepository _writerQueryRepository;
        private readonly IFileManagementCommandRepository _fileManagementCommandRepository;
        public AddWriterCommandHandler(IWriterCommandRepository writerCommandRepository,
            IWriterQueryRepository writerQueryRepository,
            IFileManagementCommandRepository fileManagementCommandRepository)
        {
            _writerCommandRepository = writerCommandRepository;
            _writerQueryRepository = writerQueryRepository;
            _fileManagementCommandRepository = fileManagementCommandRepository;
        }

        public override CommandResult Handle(AddWriterCommand entity)
        {
            long? photoId = null;
            if (IsValid(entity))
            {
                if (entity.Photo != null)
                {
                    photoId = _fileManagementCommandRepository.Add(new FileManagement
                    {
                        Url = entity.Photo.FileUrl,
                        Type = entity.Photo.FileType,
                        Name = entity.Photo.FileName,
                        Size = entity.Photo.FileSize,
                        Date = System.DateTime.Now
                    });
                }
                _writerCommandRepository.Add(new Writer()
                {
                    Name = entity.Name,
                    PhotoId = photoId
                });
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddWriterCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.Name))
            {
                AddError("نام را وارد کنید");
                isValid = false;
            }
            else if (_writerQueryRepository.IsExist(command.Name))
            {
                AddError("این نام وجود دارد");
                isValid = false;
            }
            if (command.Photo != null)
            {
                if (!string.IsNullOrEmpty(command.Photo.FileUrl) && string.IsNullOrEmpty(command.Photo.FileType))
                {
                    AddError("فایل آپلود نشده است");
                    isValid = false;
                }
                if (string.IsNullOrEmpty(command.Photo.FileUrl) && !string.IsNullOrEmpty(command.Photo.FileType))
                {
                    AddError("نوع فایل مشکل دارد");
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}
