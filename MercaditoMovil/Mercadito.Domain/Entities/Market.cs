namespace MercaditoMovil.Domain.Entities
{
    /// <summary>
    /// Feria del agricultor donde se realizan las compras.
    /// </summary>
    public class Market
    {
        public string MarketId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
    }
}
