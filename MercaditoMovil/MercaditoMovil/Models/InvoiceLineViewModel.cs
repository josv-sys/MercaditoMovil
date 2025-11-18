using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercaditoMovil.Views.WinForms.Models
{
    /// <summary>
    /// Representa una linea dentro de la factura mostrada en pantalla.
    /// </summary>
    public class InvoiceLineViewModel
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
