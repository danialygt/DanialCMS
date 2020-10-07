using DanialCMS.Core.Domain.PublishPlaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.PublishPlaces.Repositories
{
    public interface IPublishPlaceQueryRepository
    {
        PublishPlace Get(long id);
        List<PublishPlace> GetAll();
    }
}
