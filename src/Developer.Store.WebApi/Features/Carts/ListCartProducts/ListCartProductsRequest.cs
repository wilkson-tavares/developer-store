namespace Developer.Store.WebApi.Features.Carts.ListCartProducts
{
    /// <summary>
    /// Request model for getting a product int cart by ID
    /// </summary>
    public class ListCartProductsRequest
    {
        /// <summary>
        /// The unique identifier of the Cart to retrieve
        /// </summary>
        public Guid Id { get; set; }
    }
}
