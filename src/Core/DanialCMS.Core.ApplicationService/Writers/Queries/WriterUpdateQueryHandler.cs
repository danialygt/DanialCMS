using DanialCMS.Core.Domain.Writers.Dtos;
using DanialCMS.Core.Domain.Writers.Queries;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DanialCMS.Core.ApplicationService.Writers.Queries
{
    public class WriterUpdateQueryHandler : IQueryHandler<WriterUpdateQuery, DtoUpdateWriter>
    {
        private readonly IWriterQueryRepository _writerQueryRepository;
        public WriterUpdateQueryHandler(IWriterQueryRepository writerQueryRepository)
        {
            _writerQueryRepository = writerQueryRepository;
        }

        public DtoUpdateWriter Handle(WriterUpdateQuery query)
        {
            var writer = _writerQueryRepository.Get(query.Id);
            if (writer == null)
            {
                return null;
            }
            return new DtoUpdateWriter() 
            {
                Name = writer.Name,
                PhotoId = writer.PhotoId,
                PhotoUrl = (writer.Photo == null)? null: writer.Photo.Url,
            };
        }
    }
}
