using Developer.Store.Application.Products.UpdateProduct;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.UpdateProduct
{
    /// <summary>
    /// Handler for processing UpdateProductCommand requests
    /// </summary>
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
    {
        private readonly IProductRepository _ProductRepository;

        /// <summary>
        /// Initializes a new instance of UpdateProductHandler
        /// </summary>
        /// <param name="ProductRepository">The Product repository</param>
        /// <param name="validator">The validator for UpdateProductCommand</param>
        public UpdateProductHandler(
            IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        /// <summary>
        /// Handles the UpdateProductCommand request
        /// </summary>
        /// <param name="request">The UpdateProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The result of the Update operation</returns>
        public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _ProductRepository.UpdateAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            return new UpdateProductResponse { Success = true };
        }
    }
}
