using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DanialCMS.Core.Domain.Categories.Queries;
using DanialCMS.Core.Domain.Categories.Repositories;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Framework.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace DanialCMS.EndPoints.WebUI.Models.Content
{
    public class AddContentViewModel
    {
        //writerid bayad az account gerefte beshe
        public long WriterId { get; set; }




        [Required(ErrorMessage = "عنوان را وارد کنید")]
        [MaxLength(100)]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage ="متن را وارد کنید")]
        [Display(Name = "متن")]
        public string Body { get; set; }
        
        [Required(ErrorMessage ="توضیحات را وارد کنید")]
        [MaxLength(500)]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        
        [Range(0,10)]
        [Display(Name = "امتیاز")]
        public int? Rate { get; set; }

        private static DateTime _publishDate;
        

        [Required(ErrorMessage ="تاریخ انتشار را وارد کنید")]
        [Display(Name = "تاریخ انتشار")]
        public DateTime PublishDate {
        
            get 
            { 
                if(_publishDate == DateTime.MinValue)
                {
                    _publishDate = DateTime.Now;
                }
                return _publishDate;                
            }
            set 
            { 
                if(value >= _publishDate)
                {
                    _publishDate = value;
                }
            } 
        }


       

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
                Text = c.Name
            }).ToList();
            return result;
        }
        public List<SelectListItem> GetKeywordsListItems()
        {
            var result =
            AllKeywords.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return result;
        }
        public List<SelectListItem> GetPublishPlacesListItems()
        {
            var result =
            AllPublishPlaces.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return result;
        }


    }
}