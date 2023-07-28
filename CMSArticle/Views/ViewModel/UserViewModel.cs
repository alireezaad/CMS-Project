using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMSArticle.Views.ViewModel
{
    public class UserViewModel
    {
        [Key]
        [Required]
        [Display(Name = "آیدی")]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "شماره تلفن")]
        public string Phonenumber { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "تایید رمز عبور")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور شما مطابقت ندارد!")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "تاریخ ثبت")]
        [DisplayFormat(DataFormatString = "{0: dddd, dd MMMM yyyy}")]
        public DateTime RegisterDate { get; set; }
        [Required]
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        public IEnumerable<Article> articles { get; set; }
    }
}