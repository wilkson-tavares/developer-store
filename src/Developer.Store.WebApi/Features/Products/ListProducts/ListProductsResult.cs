﻿using Developer.Store.WebApi.Features.Products.Common;

namespace Developer.Store.WebApi.Features.Products.ListProducts
{
    /// <summary>
    /// Represents the result of a GetProductsQuery request.
    /// </summary>
    public class ListProductsResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public Rating Rating { get; set; } = new Rating();
    }
}
