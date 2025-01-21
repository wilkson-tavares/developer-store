using Developer.Store.Application.Products.DeleteProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.DeleteProduct
{
    /// <summary>
    /// Command for deleting a Product
    /// </summary>
    public record DeleteProductCommand : IRequest<DeleteProductResponse>
    {
        /// <summary>
        /// The unique identifier of the Product to delete
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of DeleteProductCommand
        /// </summary>
        /// <param name="id">The ID of the Product to delete</param>
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
