using Developer.Store.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.AddProductToCart
{
    /// <summary>
    /// Command for adding a product to a cart.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for adding a product to a cart, 
    /// including the cart ID, product ID, and quantity. It implements <see cref="IRequest{TResponse}"/> 
    /// to initiate the request that returns a <see cref="AddProductToCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="AddProductToCartCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class AddProductToCartCommand : IRequest<AddProductToCartResult>
    {
        /// <summary>
        /// Gets or sets the ID of the cart to which the product will be added.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product to be added to the cart.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product to be added to the cart.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Validates the command using the <see cref="AddProductToCartCommandValidator"/>.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> containing validation results.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new AddProductToCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
