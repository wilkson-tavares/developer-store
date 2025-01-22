namespace Developer.Store.WebApi.Features.Products.UpdateProduct
{
    /// <summary>
    /// Request model for deleting a Product
    /// </summary>
    public class UpdateProductRequest
    {
        /// <summary>
        /// The unique identifier of the Product to Update
        /// </summary>
        public Guid Id { get; set; }
    }
}
