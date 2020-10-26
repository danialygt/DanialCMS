using DanialCMS.Core.Domain.Contents.Commands;
using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.ApplicationService.Contents.Commands
{
    public class EditContentCommandHandler : CommandHandler<EditContentCommand>
    {
        private readonly IContentCommandRepository _contentCommandRepository;

        private readonly IContentKeywordsCommandRepository _contentKeywordsCommandRepository;
        private readonly IContentKeywordsQueryRepository _contentKeywordsQueryRepository;

        private readonly IContentPlacesQueryRepository _contentPlacesQueryRepository;
        private readonly IContentPlacesCommandRepository _contentPlacesCommandRepository;


        private readonly IFileManagementQueryRepository _fileManagementQueryRepository;

        public EditContentCommandHandler(IContentCommandRepository contentCommandRepository,
            IContentKeywordsCommandRepository contentKeywordsCommandRepository,
            IContentKeywordsQueryRepository contentKeywordsQueryRepository,
            IContentPlacesCommandRepository contentPlacesCommandRepository,
            IContentPlacesQueryRepository contentPlacesQueryRepository,
            IFileManagementQueryRepository fileManagementQueryRepository)
        {
            _contentCommandRepository = contentCommandRepository;
            _contentKeywordsCommandRepository = contentKeywordsCommandRepository;
            _contentKeywordsQueryRepository = contentKeywordsQueryRepository;

            _contentPlacesCommandRepository = contentPlacesCommandRepository;
            _contentPlacesQueryRepository = contentPlacesQueryRepository;
            _fileManagementQueryRepository = fileManagementQueryRepository;
        }

        public override CommandResult Handle(EditContentCommand command)
        {
            if (IsValid(command))
            {
                UpdateKeyword(command);
                UpdatePublishPlace(command);

                _contentCommandRepository.Update(new DtoUpdateContent()
                {
                    Id = command.Id,
                    Title = command.Title,
                    Body = command.Body,
                    Description = command.Description,
                    Rate = command.Rate,
                    PublishDate = command.PublishDate,
                    CategoryId = command.CategoryId,
                });


                // inja tasvire ham bayad update beshe!

                return Ok();
            }
            return Failure();
        }

        private void UpdateKeyword(EditContentCommand command)
        {
            var dbkeywords = _contentKeywordsQueryRepository.GetKeywordsId(command.Id);
            if (dbkeywords == null)
            {
                if (command.KeywordsId != null)
                {
                    foreach (var item in command.KeywordsId)
                    {
                        _contentKeywordsCommandRepository.Add(new ContentKeywords()
                        {
                            ContentId = command.Id,
                            KeywordId = item
                        });
                    }
                }
            }
            else
            {
                _contentKeywordsCommandRepository.RemoveKeywordsFromContent(command.Id);

                if (command.KeywordsId != null)
                {
                    foreach (var item in command.KeywordsId)
                    {
                        _contentKeywordsCommandRepository.Add(new ContentKeywords()
                        {
                            ContentId = command.Id,
                            KeywordId = item
                        });
                    }
                }
            }
        }

        private void UpdatePublishPlace(EditContentCommand command)
        {
            var dbPlaces = _contentPlacesQueryRepository.GetPlacesIdFromContent(command.Id);
            if (dbPlaces == null)
            {
                if (command.publishPlacesId != null)
                {
                    foreach (var item in command.publishPlacesId)
                    {
                        _contentPlacesCommandRepository.Add(new ContentPlaces()
                        {
                            ContentId = command.Id,
                            PublishPlaceId = item
                        });
                    }
                }
            }
            else
            {
                _contentPlacesCommandRepository.RemovePlacesFromContent(command.Id);

                if (command.publishPlacesId != null)
                {
                    foreach (var item in command.publishPlacesId)
                    {
                        _contentPlacesCommandRepository.Add(new ContentPlaces()
                        {
                            ContentId = command.Id,
                            PublishPlaceId = item
                        });
                    }
                }
            }
        }



        private bool IsValid(EditContentCommand command)
        {
            bool isValid = true;

            //if (command.dtoPhoto == null)
            //{
            //    isValid = false;
            //    AddError("عکس را اضافه کنید");
            //}
            if (command.publishPlacesId == null)
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