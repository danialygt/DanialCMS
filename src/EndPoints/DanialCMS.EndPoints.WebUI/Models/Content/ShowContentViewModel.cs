using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Content
{

    public class ShowContentViewModel
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "متن")]
        public string Body { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "عکس")]
        public string PhotoUrl { get; set; }

        [Display(Name = "امتیاز")]
        public int? Rate { get; set; }



        [Display(Name = "تاریخ انتشار")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "نویسنده")]
        public string WriterName { get; set; }
        [Display(Name = "دسته بندی")]
        public string CategoryName { get; set; }

        [Display(Name = "کلیدواژه")]
        public List<string> KeywordsName { get; set; }

        [Display(Name = "جایگاه انتشار")]
        public List<string> publishPlacesName { get; set; }

        [Display(Name = "نظرات")]
        public List<Comment> Comments { get; set; }

    }
}
