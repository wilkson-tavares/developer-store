using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Developer.Store.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of UserRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public UserRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new user in the database
    /// </summary>
    /// <param name="user">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    /// <summary>
    /// Retrieves a list of users with pagination and sorting
    /// </summary>
    /// <param name="page">Page number for pagination</param>
    /// <param name="size">Number of items per page</param>
    /// <param name="order">Ordering of results</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of users</returns>
    public async Task<(IEnumerable<User> Users, int TotalItems)> GetUsersAsync(int page = 1, int size = 10, string? order = null, CancellationToken cancellationToken = default)
    {
        var query = _context.Users.AsQueryable();

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
        var users = await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);

        return (users, totalItems);
    }

    /// <summary>
    /// Retrieves a user by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a user by their email address
    /// </summary>
    /// <param name="email">The email address to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email.Value == email, cancellationToken);
    }

    /// <summary>
    /// Deletes a user from the database
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await GetByIdAsync(id, cancellationToken);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing user in the database
    /// </summary>
    /// <param name="user">The user to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated user</returns>
    public async Task<bool> UpdateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await GetByIdAsync(id, cancellationToken);
        if (user == null)
            return false;

        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static Expression<Func<User, object>> GetPropertyExpression(string propertyName)
    {
        var parameter = Expression.Parameter(typeof(User), "x");
        var property = Expression.Property(parameter, propertyName);
        var converted = Expression.Convert(property, typeof(object));
        return Expression.Lambda<Func<User, object>>(converted, parameter);
    }
}
