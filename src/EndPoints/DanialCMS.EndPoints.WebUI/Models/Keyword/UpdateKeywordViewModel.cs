using System.ComponentModel.DataAnnotations;

namespace DanialCMS.EndPoints.WebUI.Models.Keyword
{
    public class UpdateKeywordViewModel
    {
        public long KeywordId { get; set; }
        [Required(ErrorMessage = "نام را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(50, ErrorMessage = "نام باید کمتر از 50 کاراکتر باشد")]
        public string Name { get; set; }
    }

}
