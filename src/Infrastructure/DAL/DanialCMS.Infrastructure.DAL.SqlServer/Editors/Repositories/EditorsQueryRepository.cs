using DanialCMS.Core.Domain.Editors.Entities;
using DanialCMS.Core.Domain.Editors.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Editors.Repositories
{
    public class EditorsQueryRepository : IEditorsQueryRepository
    {
        private readonly ContentDbContext _contentDbContext;

        public EditorsQueryRepository(ContentDbContext contentDbContext)
        {
            _contentDbContext = contentDbContext;
        }

        public Editor Get(long id)
        {
            return _contentDbContext.Editors.AsNoTracking()
                 .FirstOrDefault(c => c.Id == id);
        }

        public Editor Get(string editorName)
        {
            return _contentDbContext.Editors.AsNoTracking()
                .FirstOrDefault(c => c.Name == editorName);
        }

        public List<Editor> GetAll()
        {
            return _contentDbContext.Editors.AsNoTracking()
                .ToList();
        }

        public bool IsExist(string editorName)
        {
            return _contentDbContext.Editors.AsNoTracking()
                .FirstOrDefault(c => c.Name == editorName) != null;
        }
    }
}
