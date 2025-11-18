namespace MercaditoMovil.Views.WinForms.Models
{
    /// <summary>
    /// Representa un item que la vista muestra dentro del carrito.
    /// </summary>
    public class CartItemViewModel
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Total => UnitPrice * Quantity;

        public override string ToString()
        {
            return $"{ProductName} x{Quantity} = ₡{Total}";
        }
    }
}
