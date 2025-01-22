using AutoMapper;
using Developer.Store.Application.Common;
using Developer.Store.Domain.Repositories;
using MediatR;

namespace Developer.Store.WebApi.Features.Products.ListProducts
{
    /// <summary>
    /// Handler for processing ListProductsQuery requests
    /// </summary>
    public class ListUsersHandler : IRequestHandler<ListProductsQuery, PagedResult<ListProductsResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ListProductsHandler
        /// </summary>
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public ListUsersHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the ListProductsQuery request
        /// </summary>
        /// <param name="query">The ListProducts query</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A paginated list of products</returns>
        public async Task<PagedResult<ListProductsResult>> Handle(ListProductsQuery query, CancellationToken cancellationToken)
        {
            var (products, totalItems) = await _productRepository.GetProductsAsync(query.Page, query.Size, query.Order, cancellationToken);
            var productResults = _mapper.Map<IEnumerable<ListProductsResult>>(products);

            return new PagedResult<ListProductsResult>(productResults, totalItems, query.Page, query.Size);
        }
    }
}
