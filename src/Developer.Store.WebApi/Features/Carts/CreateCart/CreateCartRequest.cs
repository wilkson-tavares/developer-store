namespace Developer.Store.WebApi.Features.Carts.CreateCart
{
    /// <summary>
    /// Represents a request to create a new Cart in the system.
    /// </summary>
    public class CreateCartRequest
    {
        /// <summary>
        /// Gets or sets the user ID associated with the cart to be created.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
