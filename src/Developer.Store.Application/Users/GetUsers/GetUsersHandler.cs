using AutoMapper;
using Developer.Store.Application.Common;
using Developer.Store.Application.Users.GetUser;
using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Users.GetUsers
{
    public class GetUsersHandler : IRequestHandler<PagedQuery<PagedResult<GetUsersResult>>, PagedResult<GetUsersResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PagedQuery<PagedResult<GetUsersResult>>> _validator;

        public GetUsersHandler(IUserRepository userRepository, IMapper mapper, IValidator<PagedQuery<PagedResult<GetUsersResult>>> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<PagedResult<GetUsersResult>> Handle(PagedQuery<PagedResult<GetUsersResult>> query, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(query, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var (users, totalItems) = await _userRepository.GetUsersAsync(query.Page, query.Size, query.Order, cancellationToken);
            var usersResult = _mapper.Map<IEnumerable<GetUsersResult>>(users);

            return new PagedResult<GetUsersResult>(usersResult, totalItems, query.Page, query.Size);
        }
    }
}
