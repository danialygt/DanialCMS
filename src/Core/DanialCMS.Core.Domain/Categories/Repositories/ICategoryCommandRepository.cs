using DanialCMS.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Categories.Repositories
{
    public interface ICategoryCommandRepository
    {
        void Add(Category entity);
        void Edit(Category entity);
        void EditName(Category entity);
        void Delete(Category entity);
        void Delete(long id);


    }
}
