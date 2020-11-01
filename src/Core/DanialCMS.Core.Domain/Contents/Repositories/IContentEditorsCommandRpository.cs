using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Repositories
{
    public interface IContentEditorsCommandRpository
    {
        void Add(ContentEditors entity);
        void Edit(ContentEditors entity);
        void Delete(ContentEditors entity);
        void RemoveEditorsFromContent(long contentId);

    }
}
