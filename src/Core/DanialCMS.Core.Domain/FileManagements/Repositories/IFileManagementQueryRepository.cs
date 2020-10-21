using DanialCMS.Core.Domain.FileManagements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.FileManagements.Repositories
{
    public interface IFileManagementQueryRepository
    {
        FileManagement Get(long id);
        List<FileManagement> GetWithType(string type);
        List<FileManagement> GetAll();
        bool IsExist(long id);

    }
}
