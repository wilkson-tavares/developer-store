using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.AddProductToCart
{
    /// <summary>
    /// Result for the AddProductToCartCommand.
    /// </summary>
    public class AddProductToCartResult
    {
        /// <summary>
        /// Gets or sets the added cart product.
        /// </summary>
        public CartProduct CartProduct { get; set; }
    }
}
