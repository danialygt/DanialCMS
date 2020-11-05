using DanialCMS.Core.Domain.FileManagements.Dtos;
using DanialCMS.Core.Domain.FileManagements.Queries;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.FileManagements.Queries
{
    public class GetPhotosQueryHandler : IQueryHandler<GetPhotosQuery, List<DtoPhotoList>>
    {
        private readonly IFileManagementQueryRepository _fileQueryRepository;

        public GetPhotosQueryHandler(IFileManagementQueryRepository fileManagementQueryRepository)
        {
            _fileQueryRepository = fileManagementQueryRepository;
        }

        public List<DtoPhotoList> Handle(GetPhotosQuery query)
        {
            return _fileQueryRepository.GetAllPhotos();
        }
    }
}
