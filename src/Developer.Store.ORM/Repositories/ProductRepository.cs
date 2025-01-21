using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly SalesContext _context;

    /// <summary>
    /// Initializes a new instance of ProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ProductRepository(SalesContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new product in the database
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    /// <summary>
    /// Retrieves a list of products with pagination and sorting
    /// </summary>
    /// <param name="page">Page number for pagination</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="order">Ordering of results</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of products</returns>
    public async Task<(IEnumerable<Product> Products, int TotalItems)> GetProductsAsync(int page = 1, int size = 10, string? order = null, CancellationToken cancellationToken = default)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(order))
        {
            var orderParams = order.Split(',');
            foreach (var param in orderParams)
            {
                var trimmedParam = param.Trim();
                if (trimmedParam.EndsWith(" desc"))
                {
                    var property = trimmedParam.Replace(" desc", "");
                    query = query.OrderByDescending(GetPropertyExpression(property));
                }
                else
                {
                    var property = trimmedParam.Replace(" asc", "");
                    query = query.OrderBy(GetPropertyExpression(property));
                }
            }
        }

        var totalItems = await query.CountAsync(cancellationToken);
        var products = await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);

        return (products, totalItems);
    }

    /// <summary>
    /// Retrieves a product by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Deletes a product from the database
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the product was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product == null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing product in the database
    /// </summary>
    /// <param name="product">The product to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated product</returns>
    public async Task<bool> UpdateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await GetByIdAsync(id, cancellationToken);
        if (user == null)
            return false;

        _context.Products.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Retrieves a list of all product categories
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of product categories</returns>
    public async Task<IEnumerable<string>> GetCategoriesAsync(  CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .Select(p => p.Category)
            .Distinct()
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a list of products by category with pagination and sorting
    /// </summary>
    /// <param name="category">The category to filter by</param>
    /// <param name="page">Page number for pagination</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="order">Ordering of results</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of products in the specified category</returns>
    public async Task<(IEnumerable<Product> Products, int TotalItems)> GetProductsByCategoryAsync(string category, int page = 1, int size = 10, string? order = null, CancellationToken cancellationToken = default)
    {
        var query = _context.Products.Where(p => p.Category == category).AsQueryable();

        if (!string.IsNullOrEmpty(order))
        {
            var orderParams = order.Split(',');
            foreach (var param in orderParams)
            {
                var trimmedParam = param.Trim();
                if (trimmedParam.EndsWith(" desc"))
                {
                    var property = trimmedParam.Replace(" desc", "");
                    query = query.OrderByDescending(GetPropertyExpression(property));
                }
                else
                {
                    var property = trimmedParam.Replace(" asc", "");
                    query = query.OrderBy(GetPropertyExpression(property));
                }
            }
        }

        var totalItems = await query.CountAsync(cancellationToken);
        var products = await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);

        return (products, totalItems);
    }

    private static Expression<Func<Product, object>> GetPropertyExpression(string propertyName)
    {
        var parameter = Expression.Parameter(typeof(Product), "x");
        var property = Expression.Property(parameter, propertyName);
        var converted = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<Product, object>>(converted, parameter);
    }
}