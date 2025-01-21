using Developer.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Domain.Repositories;

/// <summary>
/// Repository interface for Product entity operations
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Creates a new product in the repository
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of products with pagination and sorting
    /// </summary>
    /// <param name="page">Page number for pagination</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="order">Ordering of results</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of products</returns>
    Task<(IEnumerable<Product> Products, int TotalItems)> GetProductsAsync(int page = 1, int size = 10, string? order = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a product from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the product was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing product in the repository
    /// </summary>
    /// <param name="id">The product to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated product</returns>
    Task<bool> UpdateAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all product categories
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of product categories</returns>
    Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of products by category with pagination and sorting
    /// </summary>
    /// <param name="category">The category to filter by</param>
    /// <param name="page">Page number for pagination</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="order">Ordering of results</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of products in the specified category</returns>
    Task<(IEnumerable<Product> Products, int TotalItems)> GetProductsByCategoryAsync(string category, int page = 1, int size = 10, string? order = null, CancellationToken cancellationToken = default);
}
