using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentPlacesCommandRepository : IContentPlacesCommandRepository
    {
        private readonly ContentDbContext _contentDbContext;

        public ContentPlacesCommandRepository(ContentDbContext contentDbContext)
        {
            _contentDbContext = contentDbContext;
        }

        public void Add(ContentPlaces entity)
        {
            _contentDbContext.ContentPlaces.Add(entity);
            _contentDbContext.SaveChanges();
        }

        public void Delete(ContentPlaces entity)
        {
            _contentDbContext.ContentPlaces.Remove(entity);
            _contentDbContext.SaveChanges();
        }

        public void Edit(ContentPlaces entity)
        {
            _contentDbContext.ContentPlaces.Update(entity);
            _contentDbContext.SaveChanges();
        }
    }
}
