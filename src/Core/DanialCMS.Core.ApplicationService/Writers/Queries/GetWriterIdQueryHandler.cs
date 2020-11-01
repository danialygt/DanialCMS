using DanialCMS.Core.Domain.Writers.Queries;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Writers.Queries
{
    public class GetWriterIdQueryHandler : IQueryHandler<GetWriterIdQuery, long>
    {
        private readonly IWriterQueryRepository _writerQueryRepository;

        public GetWriterIdQueryHandler(IWriterQueryRepository writerQueryRepository)
        {
            _writerQueryRepository = writerQueryRepository;
        }

        public long Handle(GetWriterIdQuery query)
        {
            return _writerQueryRepository.GetWriterId(query.WriterName);   
        }
    }
}
