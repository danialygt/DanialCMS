using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Queries;
using DanialCMS.Core.Domain.Keywords.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Keywords.Queries
{
    public class GetKeywordsQueryHandler : IQueryHandler<GetKeywordsQuery, List<Keyword>>
    {
        private readonly IKeywordQueryRepository _keywordQueryRepository;

        public GetKeywordsQueryHandler(IKeywordQueryRepository keywordQueryRepository)
        {
            _keywordQueryRepository = keywordQueryRepository;
        }

        public List<Keyword> Handle(GetKeywordsQuery query)
        {
            return _keywordQueryRepository.Getall();
        }
    }
}
