using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetCartsAsync(int page, int size, string order);
        Task<Cart> GetCartByIdAsync(Guid id);
        Task<Cart> CreateCartAsync(Cart cart);
        Task<Cart> UpdateCartAsync(Cart cart);
        Task<bool> DeleteCartAsync(Guid id);
    }
}
