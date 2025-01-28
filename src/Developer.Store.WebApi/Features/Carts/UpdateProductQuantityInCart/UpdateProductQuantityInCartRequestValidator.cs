using Developer.Store.WebApi.Features.Carts.RemoveProductFromCart;
using FluentValidation;

namespace Developer.Store.WebApi.Features.Carts.UpdateProductQuantityInCart
{
    /// <summary>
    /// Validator for UpdateProductQuantityInCartRequest that defines validation rules for Cart deletion.
    /// </summary>
    public class UpdateProductQuantityInCartRequestValidator : AbstractValidator<UpdateProductQuantityInCartRequest>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateProductQuantityInCartRequestValidator with defined validation rules.
        /// </summary>
        public UpdateProductQuantityInCartRequestValidator()
        {
            RuleFor(request => request.CartId)
                .NotEmpty().WithMessage("Cart ID cannot be empty.");

            RuleFor(request => request.ProductId)
                .NotEmpty().WithMessage("Product ID cannot be empty.");

            RuleFor(request => request.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
