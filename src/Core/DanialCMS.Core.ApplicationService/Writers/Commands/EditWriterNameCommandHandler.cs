using DanialCMS.Core.Domain.Writers.Commands;
using DanialCMS.Core.Domain.Writers.Entities;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Writers.Commands
{
    public class EditWriterNameCommandHandler : CommandHandler<EditWriterNameCommand>
    {
        private readonly IWriterCommandRepository _writerCommandRepository; 
        private readonly IWriterQueryRepository _writerQueryRepository; 
        public EditWriterNameCommandHandler(IWriterCommandRepository writerCommandRepository,
            IWriterQueryRepository writerQueryRepository)
        {
            _writerCommandRepository = writerCommandRepository;
            _writerQueryRepository = writerQueryRepository;
        }

        public override CommandResult Handle(EditWriterNameCommand command)
        {
            if (IsValid(command))
            {
                _writerCommandRepository.EditName(new Writer
                { 
                    Id = command.Id,
                    Name = command.Name
                });
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(EditWriterNameCommand command)
        {
            bool isValid = true;
            
            if (!_writerQueryRepository.IsExist(command.Id))
            {
                AddError("این نویسنده وجود ندارد");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(command.Name))
            {
                AddError("نام را وارد کنید");
                isValid = false;
            }
            return isValid;
        }
    }
}
