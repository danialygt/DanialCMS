using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Repositories
{
    public interface IContentPlacesQueryRepository
    {
        ContentPlaces Get(long id);
        List<ContentPlaces> GetAll();
        List<ContentPlaces> GetPlaces(long contentId);
        List<ContentPlaces> GetContents(long PlaceId);

    }
}
