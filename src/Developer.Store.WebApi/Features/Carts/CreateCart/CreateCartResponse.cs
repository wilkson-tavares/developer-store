namespace Developer.Store.WebApi.Features.Carts.CreateCart
{
    public class CreateCartResponse
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
