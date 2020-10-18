using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Queries;
using DanialCMS.Core.Domain.Keywords.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Keywords.Queries
{
    public class GetKeywordQueryHandler : IQueryHandler<GetKeywordQuery, Keyword>
    {
        private readonly IKeywordQueryRepository _keywordQueryRepository;

        public GetKeywordQueryHandler(IKeywordQueryRepository keywordQueryRepository)
        {
            _keywordQueryRepository = keywordQueryRepository;
        }

        public Keyword Handle(GetKeywordQuery query)
        {
            return _keywordQueryRepository.Get(query.Id);
        }
    }
}
