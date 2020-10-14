using DanialCMS.Core.Domain.FileManagements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.FileManagements.Repositories
{
    public interface IFileManagementCommandRepository
    {

        long Add(FileManagement entity);
        void Delete(FileManagement entity);

    }
}
