using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MercaditoMovil.Views.WinForms.Models;

namespace MercaditoMovil.Views.WinForms
{
    /// <summary>
    /// Formulario que muestra la factura generada.
    /// </summary>
    public partial class InvoiceForm : Form
    {
        private readonly List<InvoiceLineViewModel> _lines;

        public InvoiceForm(
            string customerName,
            string marketName,
            List<InvoiceLineViewModel> lines,
            decimal total)
        {
            InitializeComponent();
            _lines = lines;

            LblCustomer.Text = "Customer: " + customerName;
            LblMarket.Text = "Market: " + marketName;
            LblTotal.Text = "Total: ₡" + total;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            ListItems.Items.Clear();
            for (int i = 0; i < _lines.Count; i++)
            {
                var x = _lines[i];
                ListItems.Items.Add(
                    x.ProductName + " x" + x.Quantity + " = ₡" + x.Amount);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
