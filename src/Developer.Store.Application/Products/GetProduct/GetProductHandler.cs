using AutoMapper;
using Developer.Store.Application.Products.GetProduct;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.GetProduct
{
    /// <summary>
    /// Handler for processing GetProductCommand requests
    /// </summary>
    public class GetProductByCategoryHandler : IRequestHandler<GetProductCommand, GetProductResult>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetProductHandler
        /// </summary>
        /// <param name="ProductRepository">The Product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for GetProductCommand</param>
        public GetProductByCategoryHandler(
            IProductRepository ProductRepository,
            IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetProductCommand request
        /// </summary>
        /// <param name="request">The GetProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Product details if found</returns>
        public async Task<GetProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var Product = await _ProductRepository.GetByIdAsync(request.Id, cancellationToken);
            if (Product == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            return _mapper.Map<GetProductResult>(Product);
        }
    }
}
