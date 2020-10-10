using DanialCMS.Core.Domain.Keywords.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Keywords.Repositories
{
    public interface IKeywordCommandRepository
    {
        void Add(Keyword entity);
        void Edit(Keyword entity);
        void Delete(Keyword entity);

    }
}
