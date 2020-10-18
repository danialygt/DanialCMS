using DanialCMS.Core.Domain.Writers.Dtos;
using DanialCMS.Core.Domain.Writers.Queries;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.Framework.Queries;


namespace DanialCMS.Core.ApplicationService.Writers.Queries
{
    public class WriterDetailQueryHandler : IQueryHandler<WriterDetailQuery, DtoWriterDetail>
    {
        private readonly IWriterQueryRepository _writerQueryRepository;

        public WriterDetailQueryHandler(IWriterQueryRepository writerQueryRepository)
        {
            _writerQueryRepository = writerQueryRepository;
        }
        public DtoWriterDetail Handle(WriterDetailQuery query)
        {
            var writer = _writerQueryRepository.Get(query.Id);
            if(writer == null)
            {
                return null;
            }
            return new DtoWriterDetail()
            {
                Id = writer.Id,
                Name = writer.Name,
                Contents = writer.Contents,
                PhotoUrl = (writer.Photo == null)? null:writer.Photo.Url,
            };
        }
    }
}