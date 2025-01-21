using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.DeleteProduct
{
    /// <summary>
    /// Response model for DeleteProduct operation
    /// </summary>
    public class DeleteProductResponse
    {
        /// <summary>
        /// Indicates whether the deletion was successful
        /// </summary>
        public bool Success { get; set; }
    }
}
