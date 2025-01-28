using Developer.Store.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.UpdateProductQuantityInCart
{
    /// <summary>
    /// Command for updating the quantity of a product in a cart.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for updating the quantity of a product in a cart, 
    /// including the cart ID, product ID, and new quantity. It implements <see cref="IRequest{TResponse}"/> 
    /// to initiate the request that returns a <see cref="UpdateProductQuantityInCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateProductQuantityInCartCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateProductQuantityInCartCommand : IRequest<UpdateProductQuantityInCartResult>
    {
        /// <summary>
        /// Gets or sets the ID of the cart.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the new quantity of the product in the cart.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Validates the command using the <see cref="UpdateProductQuantityInCartCommandValidator"/>.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> containing validation results.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new UpdateProductQuantityInCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
