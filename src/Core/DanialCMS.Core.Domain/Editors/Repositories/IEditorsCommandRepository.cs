using DanialCMS.Core.Domain.Editors.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Editors.Repositories
{
    public interface IEditorsCommandRepository
    {
        void Add(Editor entity);
        void Update(Editor entity);
        void Delete(long entityId);
    }
}
