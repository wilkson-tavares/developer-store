using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer.Store.Common.Validation;
using Developer.Store.Domain.Common;
using Developer.Store.Domain.Interfaces;
using Developer.Store.Domain.Validation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Developer.Store.Domain.Entities
{
    public class Sale : BaseEntity, ISale
    {
        public int SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Product> Products { get; set; }
        List<IProduct> ISale.Products => Products.Cast<IProduct>().ToList();
        public bool Cancelled { get; set; }

        public Sale()
        {
            Products = new List<Product>();
            CreatedAt = DateTime.UtcNow;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
