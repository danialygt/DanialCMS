using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Queries;
using DanialCMS.Core.Domain.Categories.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Categories.Queries
{
    public class GetcategoryQueryHandler : IQueryHandler<GetcategoryQuery, Category>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public GetcategoryQueryHandler(ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryQueryRepository = categoryQueryRepository;
        }

        public Category Handle(GetcategoryQuery query)
        {
            return _categoryQueryRepository.Get(query.Id);
            
        }
    }
}
