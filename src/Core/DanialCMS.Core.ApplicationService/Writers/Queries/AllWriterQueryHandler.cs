using DanialCMS.Core.Domain.Writers.Dtos;
using DanialCMS.Core.Domain.Writers.Queries;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.Framework.Queries;
using System.Collections.Generic;

namespace DanialCMS.Core.ApplicationService.Writers.Queries
{
    public class AllWriterQueryHandler : IQueryHandler<AllWriterQuery, List<DtoWriter>>
    {
        private readonly IWriterQueryRepository _writerQueryRepository;

        public AllWriterQueryHandler(IWriterQueryRepository writerQueryRepository)
        {
            _writerQueryRepository = writerQueryRepository;
        }
        public List<DtoWriter> Handle(AllWriterQuery query)
        {
            return _writerQueryRepository.GetAll();
        }
    }
}