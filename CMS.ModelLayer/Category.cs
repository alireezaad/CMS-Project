using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.ModelLayer
{
    public class Category : BaseEntity
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public string ImageName { get; set; }


        public IEnumerable<Article> articles { get; set; }
    }
}
