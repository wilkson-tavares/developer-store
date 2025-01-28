using Developer.Store.WebApi.Features.Carts.GetCart;
using FluentValidation;

namespace Developer.Store.WebApi.Features.Carts.GetCart
{
    /// <summary>
    /// Validator for GetCartRequest
    /// </summary>
    public class GetCartRequestValidator : AbstractValidator<GetCartRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetCartRequest
        /// </summary>
        public GetCartRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Cart ID is required");
        }
    }
}
