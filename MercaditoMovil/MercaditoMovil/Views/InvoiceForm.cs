using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Views.WinForms.Models;

namespace MercaditoMovil.Views.WinForms
{
    /// <summary>
    /// Invoice display.
    /// </summary>
    public partial class InvoiceForm : Form
    {
        public InvoiceForm(User user, List<CartItemViewModel> cart, string payment)
        {
            InitializeComponent();

            LblCustomer.Text = "Cliente: " +
                               user.FirstName + " " +
                               user.LastName1 + " " +
                               user.LastName2;

            LblPayment.Text = "Metodo de pago: " + payment;

            decimal total = 0;

            for (int i = 0; i < cart.Count; i++)
            {
                CartItemViewModel item = cart[i];

                string line =
                    item.ProductName +
                    " x" + item.Quantity +
                    " – ₡" + item.Total;

                ListInvoice.Items.Add(line);

                total += item.Total;
            }

            LblTotal.Text = "Total: ₡" + total;
        }
    }
}
