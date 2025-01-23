using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<Cart>> GetCartsAsync(int page, int size, string order)
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
            query = query.Skip((page - 1) * size).Take(size);

            return await query.Include(c => c.CartProducts).ThenInclude(cp => cp.Product).ToListAsync();
        }

        public async Task<Cart> GetCartByIdAsync(Guid id)
        {
            return await _context.Carts
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cart> CreateCartAsync(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> UpdateCartAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<bool> DeleteCartAsync(Guid id)
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
    }
}
