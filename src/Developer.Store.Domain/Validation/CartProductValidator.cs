using Developer.Store.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Validation
{
    public class CartProductValidator : AbstractValidator<CartProduct>
    {
        public CartProductValidator()
        {
            RuleFor(cartProduct => cartProduct.Product)
                .NotNull().WithMessage("Product must not be null.");

            RuleFor(cartProduct => cartProduct.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
