namespace MercaditoMovil.Domain.Entities
{
    /// <summary>
    /// Represents a complete product available for purchase.
    /// </summary>
    public class Product
    {
        public string ProductCatalogId { get; }
        public string ProducerId { get; }
        public string Name { get; }
        public string Unit { get; }
        public string Packaging { get; }
        public decimal Price { get; }
        public int Stock { get; }

        /// <summary>
        /// Creates a new Product with all required fields.
        /// </summary>
        public Product(
            string productCatalogId,
            string producerId,
            string name,
            string unit,
            string packaging,
            decimal price,
            int stock)
        {
            ProductCatalogId = productCatalogId ?? string.Empty;
            ProducerId = producerId ?? string.Empty;
            Name = name ?? string.Empty;
            Unit = unit ?? string.Empty;
            Packaging = packaging ?? string.Empty;
            Price = price;
            Stock = stock;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
