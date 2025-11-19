using System;

namespace MercaditoMovil.Views.WinForms.Models
{
    /// <summary>
    /// View model used in the shopping cart and invoice.
    /// </summary>
    public class CartItemViewModel
    {
        /// <summary>
        /// Catalog identifier (for example CAT-0001).
        /// </summary>
        public string ProductCatalogId { get; set; } = string.Empty;

        /// <summary>
        /// Producer identifier (for example PR-001).
        /// </summary>
        public string ProducerId { get; set; } = string.Empty;

        /// <summary>
        /// Display name of the product.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Quantity selected by the user.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price for this product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Total amount for this line (UnitPrice * Quantity).
        /// </summary>
        public decimal Total
        {
            get { return UnitPrice * Quantity; }
        }
    }
}

