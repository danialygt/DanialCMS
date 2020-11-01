using DanialCMS.Core.Domain.Editors.Entities;
using DanialCMS.Core.Domain.Editors.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Editors.Repositories
{
    public class EditorsCommandRepository : IEditorsCommandRepository
    {
        private readonly ContentDbContext _contentDbContext;

        public EditorsCommandRepository(ContentDbContext contentDbContext)
        {
            _contentDbContext = contentDbContext;
        }

        public void Add(Editor entity)
        {
            _contentDbContext.Editors.Add(entity);
            _contentDbContext.SaveChanges();
        }

        public void Delete(long entityId)
        {
            var ent = _contentDbContext.Editors.FirstOrDefault(c => c.Id == entityId);
            _contentDbContext.Editors.Remove(ent);
            _contentDbContext.SaveChanges();
        }

        public void Update(Editor entity)
        {
            var ent = _contentDbContext.Editors.FirstOrDefault(c => c.Id == entity.Id);
            ent.Name = entity.Name;
            _contentDbContext.Editors.Update(ent);
            _contentDbContext.SaveChanges();
        }
    }
}
