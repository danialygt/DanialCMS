using DanialCMS.Core.Domain.Keywords.Commands;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Keywords.Commands
{
    public class AddKeywordCommandHandler : CommandHandler<AddKeywordCommand>
    {
        private readonly IKeywordCommandRepository _keywordCommandRepository;
        private readonly IKeywordQueryRepository _keywordQueryRepository;

        public AddKeywordCommandHandler(IKeywordCommandRepository keywordCommandRepository,
            IKeywordQueryRepository keywordQueryRepository)
        {
            _keywordCommandRepository = keywordCommandRepository;
            _keywordQueryRepository = keywordQueryRepository;
        }

        public override CommandResult Handle(AddKeywordCommand command)
        {
            if (IsValid(command))
            {
                _keywordCommandRepository.Add(new Keyword()
                {
                    Name = command.Name
                });
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddKeywordCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.Name))
            {
                isValid = false;
                AddError("نام را وارد کنید");
            }
            if (command.Name.Length > 50)
            {
                isValid = false;
                AddError("طول نباید بیشتر از 50 کاراکتر باشد");
            }
            if (_keywordQueryRepository.IsExist(command.Name))
            {
                isValid = false;
                AddError("این نام وجود دارد");
            }
            return isValid;
        }
    }
}
