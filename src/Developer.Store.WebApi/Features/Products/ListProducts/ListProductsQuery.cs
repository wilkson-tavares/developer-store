using Developer.Store.Application.Common;
using MediatR;

namespace Developer.Store.WebApi.Features.Products.ListProducts
{
    /// <summary>
    /// Query for retrieving a list of products with pagination and sorting.
    /// </summary>
    public class ListProductsQuery : IRequest<PagedResult<ListProductsResult>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? Order { get; set; }

        public ListProductsQuery(int page = 1, int size = 10, string? order = null)
        {
            Page = page;
            Size = size;
            Order = order;
        }
    }
}
