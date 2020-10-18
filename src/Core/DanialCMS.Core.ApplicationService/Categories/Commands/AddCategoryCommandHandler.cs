using DanialCMS.Core.Domain.Categories.Commands;
using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Categories.Commands
{
    public class AddCategoryCommandHandler : CommandHandler<AddCategoryCommand>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public AddCategoryCommandHandler(ICategoryCommandRepository categoryCommandRepository,
            ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }

        public override CommandResult Handle(AddCategoryCommand command)
        {
            if (IsValid(command))
            {
                _categoryCommandRepository.Add(new Category
                {
                    Name = command.Name
                });
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddCategoryCommand command)
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
            if (_categoryQueryRepository.IsExist(command.Name))
            {
                isValid = false;
                AddError("این نام وجود دارد");
            }

            return isValid;
        }
    }
}
