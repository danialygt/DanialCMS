using DanialCMS.Core.Domain.Keywords.Commands;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Keywords.Commands
{
    public class RemoveKeywordCommandHandler : CommandHandler<RemoveKeywordCommand>
    {
        private readonly IKeywordCommandRepository _keywordCommandRepository;
        private readonly IKeywordQueryRepository _keywordQueryRepository;

        public RemoveKeywordCommandHandler(IKeywordCommandRepository keywordCommandRepository,
            IKeywordQueryRepository keywordQueryRepository)
        {
            _keywordCommandRepository = keywordCommandRepository;
            _keywordQueryRepository = keywordQueryRepository;
        }

        public override CommandResult Handle(RemoveKeywordCommand command)
        {
            if (IsValid(command))
            {
                _keywordCommandRepository.Delete(new Keyword() { Id = command.Id });
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(RemoveKeywordCommand command)
        {
            bool isValid = true;
            if (!_keywordQueryRepository.IsExist(command.Id))
            {
                isValid = false;
                AddError("این کلید واژه وجود ندارد");
            }
            return isValid;
        }
    }
}
