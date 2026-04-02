using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOS.ProductDtos
{
    public class CreateProductDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public decimal? PriceAfterDiscount { get; set; }

        public string Colors { get; set; } = null!;
        public string Sizes { get; set; } = null!;

        public string ImageCover { get; set; } = null!;
        public string Images { get; set; } = null!;

        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
