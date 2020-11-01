using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Repositories
{
    public interface IContentEditorsQueryRpository
    {
        ContentEditors Get(long id);
        List<ContentEditors> GetAll();
        List<long> GetEditorsId(long contentId);
        List<ContentEditors> GetContents(long editorId);
    }
}
