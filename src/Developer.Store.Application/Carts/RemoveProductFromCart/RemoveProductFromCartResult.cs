using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.RemoveProductFromCart
{
    /// <summary>
    /// Result for the RemoveProductFromCartCommand.
    /// </summary>
    public class RemoveProductFromCartResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether the product was successfully removed from the cart.
        /// </summary>
        public bool Success { get; set; }
    }
}
