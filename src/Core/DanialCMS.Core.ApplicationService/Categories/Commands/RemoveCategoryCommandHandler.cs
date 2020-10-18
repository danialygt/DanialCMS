using DanialCMS.Core.Domain.Categories.Commands;
using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Categories.Commands
{
    public class RemoveCategoryCommandHandler : CommandHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public RemoveCategoryCommandHandler(ICategoryCommandRepository categoryCommandRepository,
            ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }

        public override CommandResult Handle(RemoveCategoryCommand command)
        {
            if (IsValid(command))
            {
                _categoryCommandRepository.Delete(command.Id);
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(RemoveCategoryCommand command)
        {
            bool isValid = true;
            if (!_categoryQueryRepository.IsExist(command.Id))
            {
                isValid = false;
                AddError("این دسته بندی وجود ندارد");
            }
            return isValid;
        }
    }
}
