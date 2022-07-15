using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_API_CRUD_Assignment.ViewModels
{
    public class AddCarViewModels
    {
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Category { get; set; }
        [Required]
        public Nullable<int> Price { get; set; }
    }
}
