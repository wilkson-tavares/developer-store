using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer.Store.Domain.Entities;
using FluentValidation;

namespace Developer.Store.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .GreaterThan(0)
                .WithMessage("Sale number must be greater than 0.");

            RuleFor(sale => sale.Date)
                .NotEmpty()
                .WithMessage("Sale date must not be empty.");

            RuleFor(sale => sale.Products)
                .NotEmpty()
                .WithMessage("Sale must have at least one product.")
                .Must(products => products.All(p => p.Quantity > 0))
                .WithMessage("All products must have a quantity greater than 0.")
                .Must(products => products.All(p => p.UnitPrice > 0))
                .WithMessage("All products must have a unit price greater than 0.")
                .ForEach(product => product.SetValidator(new ProductValidator()));

            RuleFor(sale => sale.TotalAmount)
                .GreaterThan(0)
                .WithMessage("Total amount must be greater than 0.");

            RuleForEach(sale => sale.Products)
                .Must(product => product.Quantity <= 20)
                .WithMessage("Cannot sell more than 20 identical items.")
                .Must(product => product.Quantity < 4 || product.Discount == 0)
                .WithMessage("Purchases below 4 items cannot have a discount.")
                .Must(product => product.Quantity >= 4 && product.Quantity < 10 && product.Discount == product.UnitPrice * product.Quantity * 0.10m ||
                                 product.Quantity >= 10 && product.Quantity <= 20 && product.Discount == product.UnitPrice * product.Quantity * 0.20m ||
                                 product.Quantity < 4 && product.Discount == 0)
                .WithMessage("Invalid discount for the quantity of items.");
        }
    }
}
