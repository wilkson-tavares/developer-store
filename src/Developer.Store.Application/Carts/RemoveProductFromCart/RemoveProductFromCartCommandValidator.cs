using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.RemoveProductFromCart
{
    /// <summary>
    /// Validator for the RemoveProductFromCartCommand.
    /// </summary>
    public class RemoveProductFromCartCommandValidator : AbstractValidator<RemoveProductFromCartCommand>
    {
        public RemoveProductFromCartCommandValidator()
        {
            RuleFor(x => x.CartId).NotEmpty().WithMessage("CartId is required.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required.");
        }
    }
}
