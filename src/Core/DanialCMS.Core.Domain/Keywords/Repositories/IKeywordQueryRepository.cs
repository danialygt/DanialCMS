using DanialCMS.Core.Domain.Keywords.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Keywords.Repositories
{
    public interface IKeywordQueryRepository
    {
        Keyword Get(long id);
        List<Keyword> Getall();
        bool IsExist(string name);
        bool IsExist(long id);
    }
}
