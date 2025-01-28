namespace Developer.Store.WebApi.Features.Carts.RemoveProductFromCart
{
    /// <summary>
    /// Represents a request to remove product from Cart in the system.
    /// </summary>
    public class RemoveProductFromCartRequest
    {
        /// <summary>
        /// Gets or sets the ID of the cart from which the product will be removed.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product to be removed from the cart.
        /// </summary>
        public Guid ProductId { get; set; }
    }
}
