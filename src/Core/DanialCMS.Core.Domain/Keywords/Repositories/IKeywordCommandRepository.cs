﻿using DanialCMS.Core.Domain.Keywords.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Keywords.Repositories
{
    public interface IKeywordCommandRepository
    {
        long Add(Keyword entity);
        void Edit(long id);
        void Delete(long id);

    }
}
