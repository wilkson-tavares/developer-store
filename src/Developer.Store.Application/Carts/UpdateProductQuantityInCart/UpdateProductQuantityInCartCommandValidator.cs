using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.UpdateProductQuantityInCart
{
    /// <summary>
    /// Validator for the UpdateProductQuantityInCartCommand.
    /// </summary>
    public class UpdateProductQuantityInCartCommandValidator : AbstractValidator<UpdateProductQuantityInCartCommand>
    {
        public UpdateProductQuantityInCartCommandValidator()
        {
            RuleFor(x => x.CartId).NotEmpty().WithMessage("CartId is required.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
