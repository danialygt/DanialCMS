using DanialCMS.Core.Domain.Keywords.Commands;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Keywords.Queries
{
    public class UpdateKeywordCommandHandler : CommandHandler<UpdateKeywordCommand>
    {
        private readonly IKeywordCommandRepository _keywordCommandRepository;
        private readonly IKeywordQueryRepository _keywordQueryRepository;

        public UpdateKeywordCommandHandler(IKeywordCommandRepository keywordCommandRepository,
            IKeywordQueryRepository keywordQueryRepository)
        {
            _keywordCommandRepository = keywordCommandRepository;
            _keywordQueryRepository = keywordQueryRepository;
        }

        public override CommandResult Handle(UpdateKeywordCommand command)
        {
            if (IsValid(command))
            {
                _keywordCommandRepository.Edit(new Keyword
                {
                    Id = command.KeywordId,
                    Name = command.Name
                });
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(UpdateKeywordCommand command)
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
                AddError("طول نام نباید بیشتر از 50 کاراکتر باشد");
            }
            if (!_keywordQueryRepository.IsExist(command.KeywordId))
            {
                isValid = false;
                AddError("این کلید واژه وجود ندارد");
            }
            return isValid;
        }
    }
}
