using DanialCMS.Core.Domain.Editors.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Editors.Repositories
{
    public interface IEditorsQueryRepository
    {
        List<Editor> GetAll();
        Editor Get(long id);
        Editor Get(string editorName);
        bool IsExist(string editorName);
    }
}
