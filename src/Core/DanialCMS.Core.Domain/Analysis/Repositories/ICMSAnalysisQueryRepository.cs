using DanialCMS.Core.Domain.Analysis.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Analysis.Repositories
{
    public interface ICMSAnalysisQueryRepository
    {
        CMSAnalysis Get(long id);
        List<CMSAnalysis> GetByDate(DateTime date);
        List<CMSAnalysis> GetAll ();
    }
}
