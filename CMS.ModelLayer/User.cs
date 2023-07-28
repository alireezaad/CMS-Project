using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.ModelLayer
{
    public class User : BaseEntity
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Family { get; set; }
        [Required]
        [MaxLength(15)]
        public string Phonenumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public IEnumerable<Article> articles { get; set; }



    }
}
