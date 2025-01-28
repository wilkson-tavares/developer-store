using Developer.Store.Application.Products.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProduct
{
    /// <summary>
    /// Response model for GetProduct operation
    /// </summary>
    public class GetProductResult
    {
        /// <summary>
        /// Gets or sets the title of the product to be created.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description for the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price for the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category for the product.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the image URL for the product.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rating for the product.
        /// </summary>
        public Rating Rating { get; set; } = new Rating();
    }
}
