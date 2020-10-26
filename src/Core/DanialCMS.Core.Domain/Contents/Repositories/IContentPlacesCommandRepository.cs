using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Repositories
{
    public interface IContentPlacesCommandRepository
    {
        void Add(ContentPlaces entity);
        void Edit(ContentPlaces entity);
        void Delete(ContentPlaces entity);

        void RemovePlacesFromContent(long contentId);


    }
}
