using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.UpdateProductQuantityInCart
{
    /// <summary>
    /// Result for the UpdateProductQuantityInCartCommand.
    /// </summary>
    public class UpdateProductQuantityInCartResult
    {
        /// <summary>
        /// Gets or sets the updated cart product.
        /// </summary>
        public CartProduct CartProduct { get; set; }
    }
}
