using Developer.Store.WebApi.Features.Carts.GetCart;
using FluentValidation;

namespace Developer.Store.WebApi.Features.Carts.ListCartProducts
{
    /// <summary>
    /// Validator for ListCartProductsRequest
    /// </summary>
    public class ListCartProductsRequestValidator : AbstractValidator<ListCartProductsRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetCartRequest
        /// </summary>
        public ListCartProductsRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Cart ID is required");
        }
    }
}
