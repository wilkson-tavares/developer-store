using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCartProducts
{
    /// <summary>
    /// Validator for the GetCartProductsCommand.
    /// </summary>
    public class GetCartProductsCommandValidator : AbstractValidator<GetCartProductsCommand>
    {
        public GetCartProductsCommandValidator()
        {
            RuleFor(x => x.CartId).NotEmpty().WithMessage("CartId is required.");
        }
    }
}
