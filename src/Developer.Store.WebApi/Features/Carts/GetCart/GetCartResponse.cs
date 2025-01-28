namespace Developer.Store.WebApi.Features.Carts.GetCart
{
    public class GetCartResponse
    {
        /// <summary>
        /// Gets or sets the user ID associated with the cart.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets or sets the date and time of the last update to the cart's information.
        /// </summary>
        DateTime? Date { get; set; }
    }
}
