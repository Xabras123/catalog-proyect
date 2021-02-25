using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace catalog_proyect.Models
{
    public class User
    {


        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string password { get; set; }
    }
}
