using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Queries;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.FileManagements.Queries
{
    public class GetFilesQueryHandler : IQueryHandler<GetFilesQuery, List<FileManagement>>
    {
        private readonly IFileManagementQueryRepository _fileQueryRepository;

        public GetFilesQueryHandler(IFileManagementQueryRepository fileManagementQueryRepository)
        {
            _fileQueryRepository = fileManagementQueryRepository;
        }

        public List<FileManagement> Handle(GetFilesQuery query)
        {
            return _fileQueryRepository.GetAll();
        }
    }
}
