namespace MercaditoMovil.Domain.Entities
{
    /// <summary>
    /// Productor que ofrece productos en una o varias ferias.
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
    }
}
