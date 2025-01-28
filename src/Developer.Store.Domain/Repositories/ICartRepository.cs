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
        Task<(IEnumerable<Cart> Carts, int TotalItems)> GetCartsAsync(int page, int size, string order, CancellationToken cancellationToken = default);
        Task<Cart> GetCartByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Cart> CreateCartAsync(Cart cart, CancellationToken cancellationToken = default);
        Task<Cart> UpdateCartAsync(Cart cart, CancellationToken cancellationToken = default);
        Task<bool> DeleteCartAsync(Guid id, CancellationToken cancellationToken = default);
        Task<CartProduct> AddProductToCartAsync(Guid cartId, Guid productId, int quantity, CancellationToken cancellationToken = default);
        Task<bool> RemoveProductFromCartAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default);
        Task<CartProduct> UpdateProductQuantityInCartAsync(Guid cartId, Guid productId, int quantity, CancellationToken cancellationToken = default);
        Task<IEnumerable<CartProduct>> GetCartProductsAsync(Guid cartId, CancellationToken cancellationToken = default);
    }
}
