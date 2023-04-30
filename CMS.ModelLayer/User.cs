using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.ModelLayer
{
    public class User: BaseEntity
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
        [MaxLength(15)]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public IEnumerable<Article> articles { get; set; }



    }
}
