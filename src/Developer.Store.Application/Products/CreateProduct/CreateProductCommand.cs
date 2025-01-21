using Developer.Store.Application.Products.Common;
using Developer.Store.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.CreateProduct
{
    /// <summary>
    /// Command for creating a new product.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a product, 
    /// including title, description, price, category, image, and rating. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateProductCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        /// <summary>
        /// Gets or sets the title of the product to be created.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description for the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price for the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category for the product.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the image URL for the product.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rating for the product.
        /// </summary>
        public Rating Rating { get; set; } = new Rating();

        /// <summary>
        /// Validates the command using the <see cref="CreateProductCommandValidator"/>.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> containing validation results.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
