using Developer.Store.Application.Products.UpdateProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.UpdateProduct
{
    /// <summary>
    /// Command for deleting a Product
    /// </summary>
    public record UpdateProductCommand : IRequest<UpdateProductResponse>
    {
        /// <summary>
        /// The unique identifier of the Product to Update
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of UpdateProductCommand
        /// </summary>
        /// <param name="id">The ID of the Product to Update</param>
        public UpdateProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
