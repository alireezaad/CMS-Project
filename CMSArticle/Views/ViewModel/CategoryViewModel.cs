using CMS.ModelLayer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMSArticle.Views.ViewModel
{
    public class CategoryViewModel
    {
        [Key]
        [Required]
        [Display(Name = "شماره دسته بندی")]
        public int CategoryId { get; set; }
        [Display(Name = "عنوان دسته بندی ")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "تعداد حروف {0}  باید بین 5 و 20 حرف باشد")]
        public string Title { get; set; }
        [Display(Name = "تصویر دسته بندی")]
        public string ImageName { get; set; }


        public IEnumerable<Article> articles { get; set; }

    }
}