using Developer.Store.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.CreateCart
{
    /// <summary>
    /// Command for creating a new cart.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a cart, 
    /// including the user ID. It implements <see cref="IRequest{TResponse}"/> 
    /// to initiate the request that returns a <see cref="CreateCartResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="CreateCartCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateCartCommand : IRequest<CreateCartResult>
    {
        /// <summary>
        /// Gets or sets the user ID associated with the cart to be created.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Validates the command using the <see cref="CreateCartCommandValidator"/>.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> containing validation results.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
