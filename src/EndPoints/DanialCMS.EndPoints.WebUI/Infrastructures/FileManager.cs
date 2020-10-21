using DanialCMS.Core.Domain.FileManagements.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace DanialCMS.EndPoints.WebUI.Infrastructures
{
    public class FileManager
    {
        public void Delete(string url)
        {
            if (url != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", url);
                File.Delete(path);
            }
        }


        public DtoFile Save(IFormFile formFile, string folderName = "photos", bool shouldImage = false)
        {
            if (formFile != null && formFile.Length > 0)
            {
                if (!IsValidType(formFile, shouldImage))
                {
                    throw new TypeAccessException($"فایل با پسوند '{formFile.ContentType}' مجاز نیست");
                }
                if (string.IsNullOrEmpty(folderName))
                {
                    folderName = "photos";
                }

                var fileName = formFile.FileName;
                
                var fileExtention = Path.GetExtension(fileName);
                if (fileName.Length > 30)
                {
                    fileName = fileName.Substring(0, 30);
                }
                var fileNameNew = $"{Guid.NewGuid()}{fileExtention}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", folderName, fileNameNew);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                    
                }
                return new DtoFile
                {
                    FileUrl = $"/{folderName}/{fileNameNew}",
                    FileType = formFile.ContentType,
                    FileName = fileName,
                    FileSize = formFile.Length,
                };
            }

            return null;
        }

        private bool IsValidType(IFormFile formFile, bool shouldImage)
        {
            bool isValid = false;
            if (formFile.ContentType.ToLower().Contains("audio") || 
                formFile.ContentType.ToLower().Contains("video") ||
                formFile.ContentType.ToLower().Contains("image") || 
                formFile.ContentType.ToLower().Contains("application/pdf") ||
                formFile.ContentType.ToLower().Contains("application/msword") ||
                formFile.ContentType.ToLower().Contains("application/vnd.ms-excel") ||
                formFile.ContentType.ToLower().Contains("application/vnd.ms-powerpoint") ||
                formFile.ContentType.ToLower().Contains("officedocument") || 
                formFile.ContentType.ToLower().Contains("text/plain") )
            {
                isValid = true;
            }
            if (shouldImage && !formFile.ContentType.ToLower().Contains("image"))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
