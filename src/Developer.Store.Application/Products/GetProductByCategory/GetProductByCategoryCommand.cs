using Developer.Store.Application.Products.GetProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProductByCategory
{
    /// <summary>
    /// Command for retrieving a Product by their category
    /// </summary>
    public record GetProductByCategoryCommand : IRequest<GetProductByCategoryResult>
    {
        /// <summary>
        /// The product category
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Initializes a new instance of GetProductCommand
        /// </summary>
        /// <param name="id">The ID of the Product to retrieve</param>
        public GetProductByCategoryCommand(string category)
        {
            Category = category;
        }
    }
}
