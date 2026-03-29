using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domin.Entities.ProductModule
{
    public class ProductBrand : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;

    }
}
