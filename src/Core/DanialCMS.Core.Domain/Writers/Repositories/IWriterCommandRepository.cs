using DanialCMS.Core.Domain.Writers.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Repositories
{
    public interface IWriterCommandRepository
    {
        long Add(Writer entity);
        void Edit(long id);

    }
}
