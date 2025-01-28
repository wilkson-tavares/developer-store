using Developer.Store.WebApi.Features.Carts.DeleteCart;
using FluentValidation;

namespace Developer.Store.WebApi.Features.Carts.DeleteCart
{
    /// <summary>
    /// Validator for DeleteCartRequest that defines validation rules for Cart deletion.
    /// </summary>
    public class DeleteCartRequestValidator : AbstractValidator<DeleteCartRequest>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteCartRequestValidator with defined validation rules.
        /// </summary>
        public DeleteCartRequestValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty().WithMessage("Cart ID cannot be empty.");
        }
    }
}
