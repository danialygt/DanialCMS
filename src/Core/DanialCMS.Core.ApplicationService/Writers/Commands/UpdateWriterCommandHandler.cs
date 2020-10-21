using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Core.Domain.Writers.Commands;
using DanialCMS.Core.Domain.Writers.Entities;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.Framework.Commands;

namespace DanialCMS.Core.ApplicationService.Writers.Commands
{
    public class UpdateWriterCommandHandler : CommandHandler<UpdateWriterCommand>
    {
        private readonly IWriterCommandRepository _writerCommandRepository;
        private readonly IWriterQueryRepository _writerQueryRepository;
        private readonly IFileManagementCommandRepository _fileManagementCommandRepository;
        public UpdateWriterCommandHandler(IWriterCommandRepository writerCommandRepository,
            IFileManagementCommandRepository fileManagementCommandRepository,
            IWriterQueryRepository writerQueryRepository)
        {
            _writerCommandRepository = writerCommandRepository;
            _fileManagementCommandRepository = fileManagementCommandRepository;
            _writerQueryRepository = writerQueryRepository;
        }

        public override CommandResult Handle(UpdateWriterCommand command)
        {
            long addedPhotoId;
            if (IsValid(command))
            {
                if (command.Photo != null)
                {
                    addedPhotoId = _fileManagementCommandRepository.Add(new FileManagement
                    {
                        Url = command.Photo.FileUrl,
                        Type = command.Photo.FileType,
                        Name = command.Photo.FileName,
                        Size = command.Photo.FileSize,
                        Date = System.DateTime.Now
                    });

                    _writerCommandRepository.ChangePhoto(command.WriterId, addedPhotoId);

                }
                if (command.Name != null)
                {
                    _writerCommandRepository.EditName(new Writer
                    {
                        Id = command.WriterId,
                        Name = command.Name,
                    });
                }
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(UpdateWriterCommand command)
        {
            bool isValid = true;

            if (!_writerQueryRepository.IsExist(command.WriterId))
            {
                AddError("این نویسنده وجود ندارد");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(command.Name) && command.Photo == null)
            {
                AddError("یک فیلد را تغییر دهید");
                isValid = false;
            }
            return isValid;
        }
    }
}
