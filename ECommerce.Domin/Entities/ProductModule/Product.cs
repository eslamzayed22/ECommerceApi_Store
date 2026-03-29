using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domin.Entities.ProductModule
{
    public class Product : BaseEntity<int>
    {
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int Quantity { get; set; }
        public int Sold { get; set; } = 0;

        public decimal Price { get; set; }
        public decimal? PriceAfterDiscount { get; set; }

        public string Colors { get; set; } = null!;
        public string Sizes { get; set; } = null!;

        public string ImageCover { get; set; } = null!;
        public string Images { get; set; } = null!;

        public double RatingsAverage { get; set; }
        public int RatingsQuantity { get; set; } = 0;

        #region Relations
        //Fk => Fluent API
        public int BrandId { get; set; }
        public ProductBrand Brand { get; set; }

        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        #endregion

    }
}
