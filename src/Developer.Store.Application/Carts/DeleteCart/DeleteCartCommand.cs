using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.DeleteCart
{
    /// <summary>
    /// Command for deleting a cart.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for deleting a cart, 
    /// including the cart ID. It implements <see cref="IRequest{TResponse}"/> 
    /// to initiate the request that returns a boolean indicating success or failure.
    /// </remarks>
    public class DeleteCartCommand : IRequest<DeleteCartResponse>
    {
        /// <summary>
        /// Gets or sets the ID of the cart to be deleted.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of DeleteCartCommand
        /// </summary>
        /// <param name="id">The ID of the Cart to delete</param>
        public DeleteCartCommand(Guid id)
        {
            Id = id;
        }
    }
}
