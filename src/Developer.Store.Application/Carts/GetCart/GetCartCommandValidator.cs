using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCart
{
    /// <summary>
    /// Validator for the GetCartCommand.
    /// </summary>
    public class GetCartCommandValidator : AbstractValidator<GetCartCommand>
    {
        public GetCartCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
