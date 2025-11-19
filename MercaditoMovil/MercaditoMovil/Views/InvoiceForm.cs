using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Views.WinForms.Controllers;
using MercaditoMovil.Views.WinForms.Models;

namespace MercaditoMovil.Views.WinForms.Views
{
    /// <summary>
    /// Invoice preview and confirmation form.
    /// Shows user, market, cart items and totals with taxes.
    /// On confirm delegates saving to CartController.
    /// </summary>
    public partial class InvoiceForm : Form
    {
        private readonly User _user;
        private readonly List<CartItemViewModel> _cart;
        private readonly string _paymentMethod;
        private readonly string _marketName;
        private readonly CartController _cartController;
        private readonly Action _onBack;

        private const decimal SalesTaxRate = 0.13m;   // Costa Rica VAT
        private const decimal ServiceFeeRate = 0.02m; // App service fee

        /// <summary>
        /// Initializes the invoice form with required data.
        /// </summary>
        public InvoiceForm(
            User user,
            List<CartItemViewModel> cart,
            string paymentMethod,
            string marketName,
            CartController cartController,
            Action onBack)
        {
            InitializeComponent();

            _user = user;
            _cart = cart;
            _paymentMethod = paymentMethod;
            _marketName = marketName;
            _cartController = cartController;
            _onBack = onBack;

            LoadInvoicePreview();
        }

        /// <summary>
        /// Loads labels and list with invoice information and tax breakdown.
        /// </summary>
        private void LoadInvoicePreview()
        {
            LblUser.Text = "Cliente: " +
                _user.FirstName + " " + _user.LastName1 + " " + _user.LastName2;

            LblMarket.Text = "Feria: " + _marketName;
            LblPayment.Text = "Metodo de pago: " + _paymentMethod;

            decimal subtotal = 0;

            for (int i = 0; i < _cart.Count; i++)
            {
                CartItemViewModel item = _cart[i];

                decimal lineBase = item.UnitPrice * item.Quantity;
                subtotal += lineBase;

                decimal lineTax = lineBase * SalesTaxRate;
                decimal lineService = lineBase * ServiceFeeRate;
                decimal lineTotal = lineBase + lineTax + lineService;

                string line =
                    item.ProductName +
                    "  x" + item.Quantity +
                    "  ->  CRC " +
                    lineTotal.ToString("N2", CultureInfo.InvariantCulture);

                ListInvoice.Items.Add(line);
            }

            decimal tax = subtotal * SalesTaxRate;
            decimal service = subtotal * ServiceFeeRate;
            decimal grandTotal = subtotal + tax + service;

            LblSubtotal.Text = "Subtotal: CRC " +
                subtotal.ToString("N2", CultureInfo.InvariantCulture);

            LblTax.Text = "IVA 13%: CRC " +
                tax.ToString("N2", CultureInfo.InvariantCulture);

            LblService.Text = "Servicio plataforma 2%: CRC " +
                service.ToString("N2", CultureInfo.InvariantCulture);

            LblTotal.Text = "Total a pagar: CRC " +
                grandTotal.ToString("N2", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Handles back button click, closes invoice and returns to cart.
        /// </summary>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
            _onBack?.Invoke();
        }

        /// <summary>
        /// Handles confirm button click, asks for confirmation and delegates save.
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Esta seguro de generar esta factura? " +
                "Esta accion actualizara el inventario y registrara la compra.",
                "Confirmacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            bool success = _cartController.SaveInvoice(
                _user,
                _cart,
                _paymentMethod,
                _marketName);

            if (!success)
            {
                // Controller or repository already showed the error message.
                return;
            }

            MessageBox.Show(
                "Factura generada correctamente.",
                "Exito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
            _onBack?.Invoke();
        }
    }
}

