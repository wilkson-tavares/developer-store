using Developer.Store.Application.Products.DeleteProduct;
using Developer.Store.Domain.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer.Store.Application.Products.DeleteProduct
{
    /// <summary>
    /// Handler for processing DeleteProductCommand requests
    /// </summary>
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IProductRepository _ProductRepository;

        /// <summary>
        /// Initializes a new instance of DeleteProductHandler
        /// </summary>
        /// <param name="ProductRepository">The Product repository</param>
        /// <param name="validator">The validator for DeleteProductCommand</param>
        public DeleteProductHandler(
            IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        /// <summary>
        /// Handles the DeleteProductCommand request
        /// </summary>
        /// <param name="request">The DeleteProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The result of the delete operation</returns>
        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _ProductRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found");

            return new DeleteProductResponse { Success = true };
        }
    }
}
