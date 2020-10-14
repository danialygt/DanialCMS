using DanialCMS.Core.Domain.Writers.Commands;
using DanialCMS.Core.Domain.Writers.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using DanialCMS.Core.Domain.FileManagements.Dtos;

namespace DanialCMS.Core.Domain.Writers.Repositories
{
    public interface IWriterCommandRepository
    {
        void Add(Writer entity);
        void Edit(Writer entity);
        void EditName(Writer entity);
        void ChangePhoto(long writerId, long photoId);
    }
}
