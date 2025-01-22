using AutoMapper;
using Developer.Store.Application.Common;
using Developer.Store.Application.Products.Common;
using Developer.Store.Application.Products.CreateProduct;
using Developer.Store.Application.Products.DeleteProduct;
using Developer.Store.Application.Products.GetProduct;
using Developer.Store.Application.Products.UpdateProduct;
using Developer.Store.Application.Users.DeleteUser;
using Developer.Store.Application.Users.GetUser;
using Developer.Store.Application.Users.GetUsers;
using Developer.Store.Application.Users.UpdateUser;
using Developer.Store.WebApi.Common;
using Developer.Store.WebApi.Features.Products.CreateProduct;
using Developer.Store.WebApi.Features.Products.DeleteProduct;
using Developer.Store.WebApi.Features.Products.GetProduct;
using Developer.Store.WebApi.Features.Products.ListProducts;
using Developer.Store.WebApi.Features.Products.UpdateProduct;
using Developer.Store.WebApi.Features.Users.CreateUser;
using Developer.Store.WebApi.Features.Users.DeleteUser;
using Developer.Store.WebApi.Features.Users.GetUser;
using Developer.Store.WebApi.Features.Users.UpdateUser;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Developer.Store.WebApi.Features.Products
{
    /// <summary>
    /// Controller for managing product operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ProductsController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of products with pagination and sorting
        /// </summary>
        /// <param name="page">Page number for pagination</param>
        /// <param name="size">Number of items per page</param>
        /// <param name="order">Ordering of results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A paginated list of products</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<PagedResult<ListProductsResult>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListProducts([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? order = null, CancellationToken cancellationToken = default)
        {
            var query = new PagedQuery<PagedResult<ListProductsResult>>(page, size, order);
            var validator = new PagedQueryValidator<PagedResult<ListProductsResult>>();
            var validationResult = await validator.ValidateAsync(query, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new ApiResponseWithData<PagedResult<ListProductsResult>>
            {
                Success = true,
                Message = "Users retrieved successfully",
                Data = result
            });
        }

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="request">The product creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
            {
                Success = true,
                Message = "Product created successfully",
                Data = _mapper.Map<CreateProductResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a product by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetProductRequest { Id = id };
            var validator = new GetProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetProductCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetProductResponse>
            {
                Success = true,
                Message = "User retrieved successfully",
                Data = _mapper.Map<GetProductResponse>(response)
            });
        }

        /// <summary>
        /// Updates a product by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the product to update</param>
        /// <param name="request">The product update request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated product details</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new UpdateProductRequest { Id = id };
            var validator = new UpdateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateProductCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Product updated successfully"
            });
        }

        /// <summary>
        /// Deletes a product by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the product was deleted</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteProductRequest { Id = id };
            var validator = new DeleteProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteProductCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Product deleted successfully"
            });
        }

    }
}
