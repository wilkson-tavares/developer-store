using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Developer.Store.ORM.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly SalesContext _context;

        public CartRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Cart> Carts, int TotalItems)> GetCartsAsync(int page, int size, string order, CancellationToken cancellationToken = default)
        {
            var query = _context.Carts.AsQueryable();

            // Apply ordering
            if (!string.IsNullOrEmpty(order))
            {
                var orderParams = order.Split(',');
                foreach (var param in orderParams)
                {
                    var trimmedParam = param.Trim();
                    if (trimmedParam.EndsWith("desc"))
                    {
                        query = query.OrderByDescending(e => EF.Property<object>(e, trimmedParam.Replace(" desc", "")));
                    }
                    else
                    {
                        query = query.OrderBy(e => EF.Property<object>(e, trimmedParam.Replace(" asc", "")));
                    }
                }
            }

            // Apply pagination
            var totalItems = await query.CountAsync(cancellationToken);
            var carts = await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);

            return (carts, totalItems);
        }

        public async Task<Cart> GetCartByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Carts
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cart> CreateCartAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> UpdateCartAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<bool> DeleteCartAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return false;
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CartProduct> AddProductToCartAsync(Guid cartId, Guid productId, int quantity, CancellationToken cancellationToken = default)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart == null) throw new ArgumentException("Cart not found");

            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new ArgumentException("Product not found");

            var cartProduct = new CartProduct(product, cart, quantity);
            _context.CartProducts.Add(cartProduct);
            await _context.SaveChangesAsync();

            return cartProduct;
        }

        public async Task<bool> RemoveProductFromCartAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default)
        {
            var cartProduct = await _context.CartProducts
                .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);

            if (cartProduct == null) return false;

            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CartProduct> UpdateProductQuantityInCartAsync(Guid cartId, Guid productId, int quantity, CancellationToken cancellationToken = default)
        {
            var cartProduct = await _context.CartProducts
                .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);

            if (cartProduct == null) throw new ArgumentException("CartProduct not found");

            cartProduct.Quantity = quantity;
            _context.CartProducts.Update(cartProduct);
            await _context.SaveChangesAsync();

            return cartProduct;
        }

        public async Task<IEnumerable<CartProduct>> GetCartProductsAsync(Guid cartId, CancellationToken cancellationToken = default)
        {
            return await _context.CartProducts
                .Where(cp => cp.CartId == cartId)
                .Include(cp => cp.Product)
                .ToListAsync();
        }
    }
}
