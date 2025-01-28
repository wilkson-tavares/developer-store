using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCartProducts
{
    /// <summary>
    /// Result for the GetCartProductsCommand.
    /// </summary>
    public class GetCartProductsResult
    {
        /// <summary>
        /// Gets or sets the list of cart products.
        /// </summary>
        public IEnumerable<CartProduct> CartProducts { get; set; }
    }
}
