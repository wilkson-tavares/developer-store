using Developer.Store.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Validation
{
    public class CartValidator : AbstractValidator<Cart>
    {
        public CartValidator()
        {
            RuleFor(cart => cart.UserId)
                .NotEmpty().WithMessage("User ID must not be empty.");

            RuleFor(cart => cart.CartProducts)
                .NotEmpty().WithMessage("Cart must have at least one product.")
                .Must(cartProducts => cartProducts.All(cp => cp.Validate().IsValid))
                .WithMessage("All products in the cart must be valid.");
        }
    }
}
