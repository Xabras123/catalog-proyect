using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog_proyect.Models
{
    public class CreateProductObject
    {
        public Product product { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
