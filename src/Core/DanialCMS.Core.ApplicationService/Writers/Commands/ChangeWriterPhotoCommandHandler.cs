using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Core.Domain.Writers.Commands;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Writers.Commands
{
    public class ChangeWriterPhotoCommandHandler : CommandHandler<ChangeWriterPhotoCommand>
    {
        private readonly IWriterCommandRepository _writerCommandRepository;
        private readonly IFileManagementCommandRepository _fileManagementCommandRepository;
        public ChangeWriterPhotoCommandHandler(IWriterCommandRepository writerCommandRepository,
            IFileManagementCommandRepository fileManagementCommandRepository)
        {
            _writerCommandRepository = writerCommandRepository;
            _fileManagementCommandRepository = fileManagementCommandRepository;
        }

        public override CommandResult Handle(ChangeWriterPhotoCommand command)
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
                    });
                
                    _writerCommandRepository.ChangePhoto(command.WriterId, addedPhotoId);
                    return Ok();
                }        
            }
            return Failure();
        }

        private bool IsValid(ChangeWriterPhotoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
