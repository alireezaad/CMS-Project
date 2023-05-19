using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.ModelLayer
{
    public class Article : BaseEntity
    {
        [Key]
        [Required]
        public int ArticleId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [MaxLength(100)]
        public string ImageName { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int Like { get; set; }
        public int Visit { get; set; }
        public int UserId { get; set; }
        public int CategoryId{ get; set; }


        public Category category { get; set; }
        public IEnumerable<Comment> comments { get; set; }
        public User user { get; set; }
    }
}
