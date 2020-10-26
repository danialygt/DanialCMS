using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Keywords.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Repositories
{
    public interface IContentKeywordsQueryRepository
    {
        ContentKeywords Get(long id);
        List<ContentKeywords> GetAll();
        List<long> GetKeywordsId(long contentId);
        List<ContentKeywords> GetContents(long keywordId);
        
    }
}
