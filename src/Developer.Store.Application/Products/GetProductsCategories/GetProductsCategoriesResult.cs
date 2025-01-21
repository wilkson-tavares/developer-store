using Developer.Store.Application.Products.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProductsCategories
{
    /// <summary>
    /// Response model for GetProducts operation
    /// </summary>
    public class GetProductsCategoriesResult
    {
        /// <summary>
        /// Gets or sets the category for the product.
        /// </summary>
        public string Category { get; set; } = string.Empty;

    }
}
