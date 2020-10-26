using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Queries;
using DanialCMS.Core.Domain.Contents.Repositories;
using DanialCMS.Framework.Queries;

namespace DanialCMS.Core.ApplicationService.Contents.Queries
{
    public class GetContentQueryHandler : IQueryHandler<GetContentQuery, DtoContent>
    {
        private readonly IContentQueryRepository _contentQueryRepository;

        public GetContentQueryHandler(IContentQueryRepository contentQueryRepository)
        {
            _contentQueryRepository = contentQueryRepository;
        }

        public DtoContent Handle(GetContentQuery query)
        {
            return _contentQueryRepository.Get(query.ContentId);
        }
    }
}
