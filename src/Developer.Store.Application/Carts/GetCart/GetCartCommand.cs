using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCart
{
    /// <summary>
    /// Query for getting a cart by ID.
    /// </summary>
    /// <remarks>
    /// This query is used to capture the required data for retrieving a cart, 
    /// including the cart ID. It implements <see cref="IRequest{TResponse}"/> 
    /// to initiate the request that returns a <see cref="GetCartResult"/>.
    /// </remarks>
    public class GetCartCommand : IRequest<GetCartResult>
    {
        /// <summary>
        /// Gets or sets the ID of the cart to be retrieved.
        /// </summary>
        public Guid Id { get; set; }
    }
}
