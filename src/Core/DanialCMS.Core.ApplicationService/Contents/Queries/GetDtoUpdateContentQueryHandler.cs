using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Queries;
using DanialCMS.Core.Domain.Contents.Repositories;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Contents.Queries
{
    public class GetDtoUpdateContentQueryHandler : IQueryHandler<GetContentQuery, DtoUpdateContent>
    {
        private readonly IContentQueryRepository _contentQueryRepository;

        public GetDtoUpdateContentQueryHandler(IContentQueryRepository contentQueryRepository)
        {
            _contentQueryRepository = contentQueryRepository;
        }

        public DtoUpdateContent Handle(GetContentQuery query)
        {
            DtoUpdateContent dto = new DtoUpdateContent();
            var ent = _contentQueryRepository.Get(query.ContentId);

            dto.Body = ent.Body;
            dto.CategoryId = ent.CategoryId;
            dto.Description = ent.Description;
            dto.Id = ent.Id;
            dto.PhotoId = ent.PhotoId;
            dto.KeywordsId = ent.KeywordsId;
            dto.PublishDate = ent.PublishDate;
            dto.PublishPlacesId = ent.PublishPlacesId;
            dto.Rate = ent.Rate;
            dto.Title = ent.Title;
            dto.WriterName = ent.Writer.Name;
            dto.Editors = ent.Editors;

            return dto;
        }
    }
}
