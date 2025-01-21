using AutoMapper;
using Developer.Store.Application.Common;
using Developer.Store.Application.Products.GetProducts;
using Developer.Store.Domain.Entities;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProductsCategories
{
    public class GetProductsCategoriesHandler : IRequestHandler<GetProductsCategoriesCommand, GetProductsCategoriesResult>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;

        public GetProductsCategoriesHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task<GetProductsCategoriesResult> Handle(GetProductsCategoriesCommand request, CancellationToken cancellationToken)
        {
            var categories = await _ProductRepository.GetCategoriesAsync(cancellationToken);
            if (categories == null)
                throw new KeyNotFoundException($"Product categories not found");

            return _mapper.Map<GetProductsCategoriesResult>(categories);
        }
    }
}
