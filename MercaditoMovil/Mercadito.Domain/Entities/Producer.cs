namespace MercaditoMovil.Domain.Entities
{
    /// <summary>
    /// Producer that offers products in one or more markets.
    /// </summary>
    public class Producer
    {
        public string ProducerId { get; set; } = string.Empty;
        public string ProducerCode { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string MarketId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        /// <summary>
        /// Returns a readable representation of the producer.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} ({ProducerCode})";
        }
    }
}