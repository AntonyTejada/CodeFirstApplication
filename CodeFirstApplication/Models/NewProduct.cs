using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CodeFirstApplication.Models
{
    public class NewProduct
    {
        public ProductModel Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
