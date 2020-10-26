using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Repositories
{
    public interface IContentCommandRepository
    {
        long Add(Content entity);
        void Update(DtoUpdateContent entity);
        void EditStatus(long id, ContentStatus contentStatus);
    }
}
