using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Common
{
    public class PagedQueryValidator<TResponse> : AbstractValidator<PagedQuery<TResponse>>
    {
        public PagedQueryValidator()
        {
            RuleFor(query => query.Page)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");

            RuleFor(query => query.Size)
                .GreaterThan(0).WithMessage("Page size must be greater than 0.");

            RuleFor(query => query.Order)
                .Matches(@"^[a-zA-Z0-9_]+( (asc|desc))?(, [a-zA-Z0-9_]+( (asc|desc))?)*$")
                .When(query => !string.IsNullOrEmpty(query.Order))
                .WithMessage("Order must be a valid ordering string.");
        }
    }
}
