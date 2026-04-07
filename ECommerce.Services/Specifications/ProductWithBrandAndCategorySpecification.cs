using ECommerce.Domin.Entities.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Specifications
{
    public class ProductWithBrandAndCategorySpecification : BaseSpecification<Product, int>
    {
        public ProductWithBrandAndCategorySpecification() : base()
        {
            AddInclude(P => P.Brand);
            AddInclude(P => P.Category);
        }
    }
}
