using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Queries;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.FileManagements.Queries
{
    public class GetFileQueryHandler : IQueryHandler<GetFileQuery, FileManagement>
    {
        private readonly IFileManagementQueryRepository _fileManagementQueryRepository;

        public GetFileQueryHandler(IFileManagementQueryRepository fileManagementQueryRepository)
        {
            _fileManagementQueryRepository = fileManagementQueryRepository;
        }

        public FileManagement Handle(GetFileQuery query)
        {
            return _fileManagementQueryRepository.Get(query.Id);
        }
    }
}
