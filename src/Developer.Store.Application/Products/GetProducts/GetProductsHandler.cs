using AutoMapper;
using Developer.Store.Application.Common;
using Developer.Store.Application.Products.GetProducts;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProducts
{
    public class GetProductsCategoriesHandler : IRequestHandler<PagedQuery<PagedResult<GetProductsCategoriesResult>>, PagedResult<GetProductsCategoriesResult>>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PagedQuery<PagedResult<GetProductsCategoriesResult>>> _validator;

        public GetProductsCategoriesHandler(IProductRepository ProductRepository, IMapper mapper, IValidator<PagedQuery<PagedResult<GetProductsCategoriesResult>>> validator)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<PagedResult<GetProductsCategoriesResult>> Handle(PagedQuery<PagedResult<GetProductsCategoriesResult>> query, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(query, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var (Products, totalItems) = await _ProductRepository.GetProductsAsync(query.Page, query.Size, query.Order, cancellationToken);
            var ProductsResult = _mapper.Map<IEnumerable<GetProductsCategoriesResult>>(Products);

            return new PagedResult<GetProductsCategoriesResult>(ProductsResult, totalItems, query.Page, query.Size);
        }
    }
}
