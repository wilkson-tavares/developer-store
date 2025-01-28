using Developer.Store.WebApi.Features.Carts.DeleteCart;
using FluentValidation;

namespace Developer.Store.WebApi.Features.Carts.RemoveProductFromCart
{
    /// <summary>
    /// Validator for RemoveProductFromCartRequest that defines validation rules for Cart deletion.
    /// </summary>
    public class RemoveProductFromCartRequestValidator : AbstractValidator<RemoveProductFromCartRequest>
    {
        /// <summary>
        /// Initializes a new instance of the RemoveProductFromCartRequestValidator with defined validation rules.
        /// </summary>
        public RemoveProductFromCartRequestValidator()
        {
            RuleFor(request => request.CartId)
                .NotEmpty().WithMessage("Cart ID cannot be empty.");

            RuleFor(request => request.ProductId)
                .NotEmpty().WithMessage("Product ID cannot be empty.");
        }
    }
}
