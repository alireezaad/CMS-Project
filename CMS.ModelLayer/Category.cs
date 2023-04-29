using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.ModelLayer
{ 
    public class Category
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
