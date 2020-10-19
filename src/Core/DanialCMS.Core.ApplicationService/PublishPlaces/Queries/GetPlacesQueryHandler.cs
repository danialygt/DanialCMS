using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Queries;
using DanialCMS.Core.Domain.PublishPlaces.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.PublishPlaces.Queries
{
    public class GetPlacesQueryHandler : IQueryHandler<GetPlacesQuery, List<PublishPlace>>
    {
        private readonly IPublishPlaceQueryRepository _publishPlaceQueryRepository;

        public GetPlacesQueryHandler(IPublishPlaceQueryRepository publishPlaceQueryRepository)
        {
            _publishPlaceQueryRepository = publishPlaceQueryRepository;
        }

        public List<PublishPlace> Handle(GetPlacesQuery query)
        {
            return _publishPlaceQueryRepository.GetAll();
        }
    }
}
