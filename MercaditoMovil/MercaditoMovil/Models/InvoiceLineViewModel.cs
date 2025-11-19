namespace MercaditoMovil.Views.WinForms.Models
{
    /// <summary>
    /// Represents a single line of the invoice shown on screen.
    /// </summary>
    public class InvoiceLineViewModel
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}

