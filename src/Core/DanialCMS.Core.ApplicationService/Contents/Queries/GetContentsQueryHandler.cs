using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Queries;
using DanialCMS.Core.Domain.Contents.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Contents.Queries
{
    public class GetContentsQueryHandler : IQueryHandler<GetContentsQuery, List<DtoListContent>>
    {
        private readonly IContentQueryRepository _contentQueryRepository;

        public GetContentsQueryHandler(IContentQueryRepository contentQueryRepository)
        {
            _contentQueryRepository = contentQueryRepository;
        }

        public List<DtoListContent> Handle(GetContentsQuery query)
        {
            return _contentQueryRepository.GetAll();
        }
    }
}
