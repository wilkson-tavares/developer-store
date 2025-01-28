using Developer.Store.Domain.Entities;

namespace Developer.Store.WebApi.Features.Carts.ListCartProducts
{
    public class ListCartProductsResponse
    {
        /// <summary>
        /// Gets or sets the cart.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
