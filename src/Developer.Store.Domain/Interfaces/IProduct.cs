using Developer.Store.Common.Validation;
using Developer.Store.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Interfaces
{
    public interface IProduct
    {
        Guid Id { get; }
        string Title { get; }
        string Description { get; }
        decimal Price { get; }
        string Category { get; }
        string Image { get; }
        Rating Rating { get; }
        DateTime? UpdatedAt { get; }
        DateTime CreatedAt { get; }
    }
}
