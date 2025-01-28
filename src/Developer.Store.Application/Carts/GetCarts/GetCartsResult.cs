using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCarts
{
    /// <summary>
    /// Result for the GetCartsCommand.
    /// </summary>
    public class GetCartsResult
    {
        /// <summary>
        /// Gets or sets the list of carts.
        /// </summary>
        public IEnumerable<Cart> Carts { get; set; }
    }
}
