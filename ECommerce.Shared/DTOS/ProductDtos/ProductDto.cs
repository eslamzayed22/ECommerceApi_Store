using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOS.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
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

        public string  ProductBrand { get; set; } = null!;
        public string ProductCategory { get; set; } = null!;
    }
}
