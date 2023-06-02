using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSArticle.Views.ViewModel
{
    public class CommentViewModel
    {
        [Key]
        [Required]
        [Display(Name = "آیدی")]
        public int CommentId { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = " نویسنده کامنت")]
        public string FullName { get; set; }
        [Required]
        [MaxLength(40)]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "محتوا")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }
        [Required]
        [Display(Name = "تاریخ درج")]
        public DateTime RegisterDate { get; set; }
        [Required]
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        public Article article { get; set; }
    }
}