using Developer.Store.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.RemoveProductFromCart
{
    /// <summary>
    /// Command for removing a product from a cart.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for removing a product from a cart, 
    /// including the cart ID and product ID. It implements <see cref="IRequest{TResponse}"/> 
    /// to initiate the request that returns a <see cref="RemoveProductFromCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="RemoveProductFromCartCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class RemoveProductFromCartCommand : IRequest<RemoveProductFromCartResult>
    {
        /// <summary>
        /// Gets or sets the ID of the cart from which the product will be removed.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product to be removed from the cart.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Validates the command using the <see cref="RemoveProductFromCartCommandValidator"/>.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> containing validation results.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new RemoveProductFromCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
