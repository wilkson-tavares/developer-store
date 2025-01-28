using AutoMapper;
using Developer.Store.Application.Common;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Carts.GetCarts
{
    public class GetCartsCategoriesHandler : IRequestHandler<PagedQuery<PagedResult<GetCartsResult>>, PagedResult<GetCartsResult>>
    {
        private readonly ICartRepository _CartRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PagedQuery<PagedResult<GetCartsResult>>> _validator;

        public GetCartsCategoriesHandler(ICartRepository CartRepository, IMapper mapper, IValidator<PagedQuery<PagedResult<GetCartsResult>>> validator)
        {
            _CartRepository = CartRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<PagedResult<GetCartsResult>> Handle(PagedQuery<PagedResult<GetCartsResult>> query, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(query, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var (Carts, totalItems) = await _CartRepository.GetCartsAsync(query.Page, query.Size, query.Order, cancellationToken);
            var CartsResult = _mapper.Map<IEnumerable<GetCartsResult>>(Carts);

            return new PagedResult<GetCartsResult>(CartsResult, totalItems, query.Page, query.Size);
        }
    }
}
