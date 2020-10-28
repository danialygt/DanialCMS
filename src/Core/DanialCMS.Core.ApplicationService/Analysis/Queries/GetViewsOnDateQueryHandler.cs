using DanialCMS.Core.Domain.Analysis.Queries;
using DanialCMS.Core.Domain.Analysis.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Analysis.Queries
{
    public class GetViewsOnDateQueryHandler : IQueryHandler<GetViewsOnDateQuery, int>
    {
        private readonly ICMSAnalysisQueryRepository _analysisQueryRepository;

        public GetViewsOnDateQueryHandler(ICMSAnalysisQueryRepository analysisQueryRepository)
        {
            _analysisQueryRepository = analysisQueryRepository;
        }

        public int Handle(GetViewsOnDateQuery query)
        {
            return _analysisQueryRepository.GetByType("html")
                .Where(c => c.Date >= DateTime.Now.Date)
                .Count();
        }
    }
}
