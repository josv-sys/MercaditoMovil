namespace MercaditoMovil.Domain.Entities
{
    /// <summary>
    /// Producto disponible para la venta en la feria.
    /// </summary>
    public class Product
    {
        public string ProductCatalogId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public string Packaging { get; set; } = string.Empty;
    }
}
