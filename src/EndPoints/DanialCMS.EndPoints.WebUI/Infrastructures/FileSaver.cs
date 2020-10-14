using DanialCMS.Core.Domain.FileManagements.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace DanialCMS.EndPoints.WebUI.Infrastructures
{
    public class FileSaver
    {
        public DtoFile Save(IFormFile formFile)
        {
            if (formFile != null && formFile.Length > 0)
            {
                var fileExtention = Path.GetExtension(formFile.FileName);
                var fileName = $"{Guid.NewGuid()}{fileExtention}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\photos", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
                return new DtoFile
                {
                    FileUrl = $"/photos/{fileName}",
                    FileType = fileExtention  /// bayad ye daste bandi ijad beshe!
                };
            }

            return null;
        }


    }
}
