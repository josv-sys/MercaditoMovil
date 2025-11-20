namespace MercaditoMovil.Domain.Entities
{
    /// <summary>
    /// Farmers market where purchases take place.
    /// </summary>
    public class Market
    {
        public string MarketId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;

        /// <summary>
        /// Returns a readable representation of the market.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} - {Province}, {Canton}, {District}";
        }
    }
}
