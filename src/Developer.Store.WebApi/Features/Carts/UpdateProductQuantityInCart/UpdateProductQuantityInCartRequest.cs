namespace Developer.Store.WebApi.Features.Carts.UpdateProductQuantityInCart
{
    /// <summary>
    /// Represents a request to update quantity of product in Cart in the system.
    /// </summary>
    public class UpdateProductQuantityInCartRequest
    {
        /// <summary>
        /// Gets or sets the ID of the cart.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the new quantity of the product in the cart.
        /// </summary>
        public int Quantity { get; set; }
    }
}
