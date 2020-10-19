using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Queries;
using DanialCMS.Core.Domain.PublishPlaces.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.PublishPlaces.Queries
{
    public class GetPlaceQueryHandler : IQueryHandler<GetPlaceQuery, PublishPlace>
    {
        private readonly IPublishPlaceQueryRepository _publishPlaceQueryRepository;

        public GetPlaceQueryHandler(IPublishPlaceQueryRepository publishPlaceQueryRepository)
        {
            _publishPlaceQueryRepository = publishPlaceQueryRepository;
        }

        public PublishPlace Handle(GetPlaceQuery query)
        {
            return _publishPlaceQueryRepository.Get(query.Id);
        }
    }
}
