using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOS.ProductDtos
{
    public class UpdateProductDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
        public decimal? PriceAfterDiscount { get; set; }

        public string? Colors { get; set; }
        public string? Sizes { get; set; }

        public string? ImageCover { get; set; }
        public string? Images { get; set; }

        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
    }
}
