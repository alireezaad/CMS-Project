using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.ModelLayer
{
    public class Comment : BaseEntity
    {
        [Key]
        [Required]
        public int CommentId { get; set; }
        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(40)]
        public string Email { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public Article article { get; set; }
    }
}
