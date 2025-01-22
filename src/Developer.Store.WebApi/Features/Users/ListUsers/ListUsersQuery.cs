using Developer.Store.Application.Common;
using MediatR;

namespace Developer.Store.WebApi.Features.Users.ListUsers
{
    /// <summary>
    /// Query for retrieving a list of Users with pagination and sorting.
    /// </summary>
    public class ListUsersQuery : IRequest<PagedResult<ListUsersResult>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? Order { get; set; }

        public ListUsersQuery(int page = 1, int size = 10, string? order = null)
        {
            Page = page;
            Size = size;
            Order = order;
        }
    }
}
