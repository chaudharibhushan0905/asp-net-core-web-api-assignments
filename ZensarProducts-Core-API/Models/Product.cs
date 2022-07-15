using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZensarProducts_Core_API.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [MaxLength(20)]
        [Required]
        public string Description { get; set; }

        [Range(5000,10000,ErrorMessage ="Product amount must be greater than 5000")]
        public Nullable<int> Amount { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
