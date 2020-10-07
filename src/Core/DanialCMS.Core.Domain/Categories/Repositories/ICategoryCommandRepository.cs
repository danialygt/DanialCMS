using DanialCMS.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Categories.Repositories
{
    public interface ICategoryCommandRepository
    {
        long Add(Category entity);
        void Edit(long id);
        void Delete(long id);


    }
}
