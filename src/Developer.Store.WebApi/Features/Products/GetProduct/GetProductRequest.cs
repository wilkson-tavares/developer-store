namespace Developer.Store.WebApi.Features.Products.GetProduct
{
    /// <summary>
    /// Request model for getting a Product by ID
    /// </summary>
    public class GetProductRequest
    {
        /// <summary>
        /// The unique identifier of the Product to retrieve
        /// </summary>
        public Guid Id { get; set; }
    }
}
