using DanialCMS.Core.Domain.Contents.Commands;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Contents.Commands
{
    public class AddContentCommandHandler : CommandHandler<AddContentCommand>
    {
        private readonly IContentCommandRepository _contentCommandRepository;
        private readonly IContentKeywordsCommandRepository _contentKeywordsCommandRepository;
        private readonly IContentPlacesCommandRepository _contentPlacesCommandRepository;
        private readonly IFileManagementCommandRepository _fileManagementCommandRepository;

        public AddContentCommandHandler(IContentCommandRepository contentCommandRepository,
            IContentKeywordsCommandRepository contentKeywordsCommandRepository,
            IContentPlacesCommandRepository contentPlacesCommandRepository,
            IFileManagementCommandRepository fileManagementCommandRepository)
        {
            _contentCommandRepository = contentCommandRepository;
            _contentKeywordsCommandRepository = contentKeywordsCommandRepository;
            _contentPlacesCommandRepository = contentPlacesCommandRepository;
            _fileManagementCommandRepository = fileManagementCommandRepository;
        }

        public override CommandResult Handle(AddContentCommand command)
        {
            if (IsValid(command))
            {
                long? dtoPhotoId = null;
                dtoPhotoId = 1;

                // inja photo bayad add beshe
                
                
                //dtoPhotoId =  _fileManagementCommandRepository.Add(new FileManagement()
                //{
                //    Name = command.dtoPhoto.FileName,
                //    Size = command.dtoPhoto.FileSize,
                //    Type = command.dtoPhoto.FileType,
                //    Url = command.dtoPhoto.FileUrl,
                //    Date = DateTime.Now
                //});

                var contentId = _contentCommandRepository.Add(new Content()
                {
                    CategoryId = command.CategoryId,
                    ContentStatus = command.ContentStatus,
                    Description = command.Description,
                    Body = command.Body,
                    Title = command.Title,
                    PublishDate = command.PublishDate,
                    WriterId = command.WriterId,
                    PhotoId = dtoPhotoId,
                    Rate = command.Rate,
                });

                foreach (var id in command.KeywordsId)
                {
                    _contentKeywordsCommandRepository.Add(new ContentKeywords()
                    {
                        ContentId = contentId,
                        KeywordId = id
                    });
                }
                foreach (var id in command.PublishPlacesId)
                {
                    _contentPlacesCommandRepository.Add(new ContentPlaces()
                    {
                        ContentId = contentId,
                        PublishPlaceId = id
                    });
                }
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(AddContentCommand command)
        {
            bool isValid = true;

            if (command.dtoPhoto == null) 
            {
                isValid = false;
                AddError("عکس را اضافه کنید");
            }
            if (command.PublishPlacesId == null)
            {
                isValid = false;
                AddError("یک جایگاه انتشار انتخاب کنید");
            }
            if (command.CategoryId == null)
            {
                isValid = false;
                AddError("دسته بندی را انتخاب کنید");
            }
            if (string.IsNullOrEmpty(command.Body))
            {
                isValid = false;
                AddError("متن را وارد کنید");
            }
            if (string.IsNullOrEmpty(command.Title))
            {
                isValid = false;
                AddError("عنوان را وارد کنید");
            }
            if (string.IsNullOrEmpty(command.Description))
            {
                isValid = false;
                AddError("توضیحات را وارد کنید");
            }

            return isValid;
        }
    
    }
}
