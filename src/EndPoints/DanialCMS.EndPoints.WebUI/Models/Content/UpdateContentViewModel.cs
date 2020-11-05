using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.FileManagements.Dtos;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Content
{
    public class UpdateContentViewModel
    {

        public long Id { get; set; }
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [MaxLength(100, ErrorMessage = "عنوان باید کمتر از 100 کاراکتر باشد")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "متن را وارد کنید")]
        [Display(Name = "متن")]
        public string Body { get; set; }

        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        [MaxLength(500, ErrorMessage = "توضیحات باید کمتر از 500 کاراکتر باشد")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        [Range(0, 10, ErrorMessage = "امتیاز باید بین 0 تا 10 باشد")]
        public int? Rate { get; set; }


        public long PhotoId { get; set; }
        public string PhotoUrl { get; set; }

        private static DateTime _publishDate;
        [Required(ErrorMessage = "تاریخ انتشار را وارد کنید")]
        [Display(Name = "تاریخ انتشار")]
        public DateTime PublishDate
        {

            get
            {
                if (_publishDate == DateTime.MinValue)
                {
                    _publishDate = DateTime.Now;
                }
                return _publishDate;
            }
            set
            {
                if (value >= _publishDate)
                {
                    _publishDate = value;
                }
            }
        }

        public string WriterName { get; set; }

        public List<DtoPhotoList> AllPhotos { get; set; }



        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "دسته بندی را وارد کنید")]
        public long CategoryId { get; set; }

        [Display(Name = "کلیدواژه")]
        public List<long> KeywordsId { get; set; }

        [Required(ErrorMessage = "جایگاه انتشار را وارد کنید")]
        [Display(Name = "جایگاه انتشار")]
        public List<long> PublishPlacesId { get; set; }


        public List<Core.Domain.Categories.Entities.Category> AllCategories { get; set; }
        public List<Core.Domain.Keywords.Entities.Keyword> AllKeywords { get; set; }
        public List<PublishPlace> AllPublishPlaces { get; set; }



        public List<SelectListItem> GetCategoriesListItems()
        {
            var result =
            AllCategories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = (CategoryId == c.Id)
            }).ToList();
            return result;
        }
        public List<SelectListItem> GetKeywordsListItems()
        {
            var result =
            AllKeywords.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = KeywordsId.Contains(c.Id)
            }).ToList();
            return result;
        }
        public List<SelectListItem> GetPublishPlacesListItems()
        {
            var result =
            AllPublishPlaces.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = PublishPlacesId.Contains(c.Id)
            }).ToList();
            return result;
        }

    }
}
