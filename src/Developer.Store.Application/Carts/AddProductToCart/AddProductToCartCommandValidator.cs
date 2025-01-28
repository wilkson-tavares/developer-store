using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.AddProductToCart
{
    /// <summary>
    /// Validator for the AddProductToCartCommand.
    /// </summary>
    public class AddProductToCartCommandValidator : AbstractValidator<AddProductToCartCommand>
    {
        public AddProductToCartCommandValidator()
        {
            RuleFor(x => x.CartId).NotEmpty().WithMessage("CartId is required.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
