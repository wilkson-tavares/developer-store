using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCartProducts
{
    /// <summary>
    /// Command for getting the products of a cart.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for getting the products of a cart, 
    /// including the cart ID. It implements <see cref="IRequest{TResponse}"/> 
    /// to initiate the request that returns a <see cref="GetCartProductsResult"/>.
    /// </remarks>
    public class GetCartProductsCommand : IRequest<GetCartProductsResult>
    {
        /// <summary>
        /// Gets or sets the ID of the cart.
        /// </summary>
        public Guid CartId { get; set; }
    }
}
