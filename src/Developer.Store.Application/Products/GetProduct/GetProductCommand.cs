using Developer.Store.Application.Products.GetProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProduct
{
    /// <summary>
    /// Command for retrieving a Product by their ID
    /// </summary>
    public record GetProductCommand : IRequest<GetProductByCategoryResult>
    {
        /// <summary>
        /// The unique identifier of the Product to retrieve
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of GetProductCommand
        /// </summary>
        /// <param name="id">The ID of the Product to retrieve</param>
        public GetProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
