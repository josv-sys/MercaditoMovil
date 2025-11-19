namespace MercaditoMovil.Views.WinForms.Models
{
    /// <summary>
    /// Represents an item in the shopping cart.
    /// </summary>
    public class CartItemViewModel
    {
        /// <summary>
        /// Product name displayed in the cart.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Quantity selected.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Total amount based on quantity and unit price.
        /// </summary>
        public decimal Total
        {
            get { return UnitPrice * Quantity; }
        }
    }
}
