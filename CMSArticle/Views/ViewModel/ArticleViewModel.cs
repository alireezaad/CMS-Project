using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMSArticle.Views.ViewModel
{
    public class ArticleViewModel
    {
        [Key]
        [Required]
        [Display(Name = "آیدی مقاله")]
        public int ArticleId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "عنوان مقاله")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "محتوای مقاله")]
        public string Content { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "تصویر شاخص")]
        public string ImageName { get; set; }

        [Required]
        [Display(Name = "تاریخ نگارش")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "لایک")]
        public int Like { get; set; }

        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        public int UserId { get; set; }


        public Category category { get; set; }
        public IEnumerable<Comment> comments { get; set; }
        public User user { get; set; }
    }
}