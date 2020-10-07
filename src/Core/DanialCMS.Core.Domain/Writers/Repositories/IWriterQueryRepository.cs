using DanialCMS.Core.Domain.Writers.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Repositories
{
    public interface IWriterQueryRepository
    {
        Writer Get(long id);
        List<Writer> Getall();

    }
}
