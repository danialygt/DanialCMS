using DanialCMS.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Categories.Repositories
{
    public interface ICategoryQueryRepository
    {

        Category Get(long id);
        List<Category> Getall();

    }
}
