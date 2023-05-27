using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSArticle.Views.ViewModel
{
    public class UserViewModel
    {

        [Required]
        [MaxLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="شماره همراه")]
        public string Phonenumber { get; set; }
        [Required]
        [MaxLength(15)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Display(Name ="مرا به خاطر بسپار")]
        public bool SavePassword { get; set; }
        public string ReturnUrl { get; set; }



    }
}