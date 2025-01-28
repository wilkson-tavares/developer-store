namespace Developer.Store.WebApi.Features.Carts.DeleteCart
{
    /// <summary>
    /// Represents a request to delete a Cart in the system.
    /// </summary>
    public class DeleteCartRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Cart to be deleted.
        /// </summary>
        public Guid Id { get; set; }
    }
}
