using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Repositories
{
    public interface IContentQueryRepository
    {
        Content Get(long id);
        List<Content> GetAll();
    }
}
