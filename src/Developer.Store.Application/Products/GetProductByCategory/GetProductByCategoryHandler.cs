using AutoMapper;
using Developer.Store.Application.Common;
using Developer.Store.Application.Products.GetProduct;
using Developer.Store.Application.Products.GetProducts;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Developer.Store.Application.Products.GetProductByCategory
{
    public class GetProductByCategoryHandler : IRequestHandler<PagedQuery<PagedResult<GetProductByCategoryResult>>, PagedResult<GetProductByCategoryResult>>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PagedQuery<PagedResult<GetProductByCategoryResult>>> _validator;

        public GetProductByCategoryHandler(IProductRepository ProductRepository, IMapper mapper, IValidator<PagedQuery<PagedResult<GetProductByCategoryResult>>> validator)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<PagedResult<GetProductByCategoryResult>> Handle(PagedQuery<PagedResult<GetProductByCategoryResult>> query, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(query, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var (Products, totalItems) = await _ProductRepository.GetProductsAsync(query.Page, query.Size, query.Order, cancellationToken);
            var ProductsResult = _mapper.Map<IEnumerable<GetProductByCategoryResult>>(Products);

            return new PagedResult<GetProductByCategoryResult>(ProductsResult, totalItems, query.Page, query.Size);
        }
    }
}
