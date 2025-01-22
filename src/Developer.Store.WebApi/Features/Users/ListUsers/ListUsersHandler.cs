using AutoMapper;
using Developer.Store.Application.Common;
using Developer.Store.Domain.Repositories;
using MediatR;

namespace Developer.Store.WebApi.Features.Users.ListUsers
{
    /// <summary>
    /// Handler for processing ListUsersQuery requests
    /// </summary>
    public class ListUsersHandler : IRequestHandler<ListUsersQuery, PagedResult<ListUsersResult>>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ListUsersHandler
        /// </summary>
        /// <param name="UserRepository">The User repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public ListUsersHandler(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the ListUsersQuery request
        /// </summary>
        /// <param name="query">The ListUsers query</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A paginated list of Users</returns>
        public async Task<PagedResult<ListUsersResult>> Handle(ListUsersQuery query, CancellationToken cancellationToken)
        {
            var (Users, totalItems) = await _UserRepository.GetUsersAsync(query.Page, query.Size, query.Order, cancellationToken);
            var UserResults = _mapper.Map<IEnumerable<ListUsersResult>>(Users);

            return new PagedResult<ListUsersResult>(UserResults, totalItems, query.Page, query.Size);
        }
    }
}
