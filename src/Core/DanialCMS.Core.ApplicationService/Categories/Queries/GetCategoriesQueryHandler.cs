using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Queries;
using DanialCMS.Core.Domain.Categories.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Categories.Queries
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public GetCategoriesQueryHandler(ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
        }

        public List<Category> Handle(GetCategoriesQuery query)
        {
            return _categoryQueryRepository.Getall();
        }
    }
}
