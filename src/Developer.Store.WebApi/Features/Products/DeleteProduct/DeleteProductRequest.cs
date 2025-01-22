namespace Developer.Store.WebApi.Features.Products.DeleteProduct
{
    /// <summary>
    /// Represents a request to delete a Product in the system.
    /// </summary>
    public class DeleteProductRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product to be deleted.
        /// </summary>
        public Guid Id { get; set; }
    }
}
