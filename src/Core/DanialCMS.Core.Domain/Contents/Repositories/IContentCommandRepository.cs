using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Repositories
{
    public interface IContentCommandRepository
    {
        void Add(Content entity);
        void Edit(Content entity);

    }
}
