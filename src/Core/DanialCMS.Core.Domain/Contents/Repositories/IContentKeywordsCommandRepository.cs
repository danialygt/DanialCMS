using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Repositories
{
    public interface IContentKeywordsCommandRepository
    {
        void Add(ContentKeywords entity);
        void Edit(ContentKeywords entity);
        void Delete(ContentKeywords entity);


    }
}
