using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Views.WinForms.Controllers;
using MercaditoMovil.Views.WinForms.Models;

namespace MercaditoMovil.Views.WinForms
{
    /// <summary>
    /// Form que permite seleccionar productos y administrar el carrito.
    /// </summary>
    public partial class CartForm : Form
    {
        private readonly CartController _controller;

        public CartForm(User user)
        {
            InitializeComponent();
            _controller = new CartController(user);

            Load += CartForm_Load;
        }

        private void CartForm_Load(object? sender, EventArgs e)
        {
            LblCustomer.Text = "Customer: " + _controller.GetUserFullName();
            LoadMarket();
            LoadProducts();
            LoadCart();
        }

        private void LoadMarket()
        {
            var market = _controller.GetMarket();
            if (market != null)
            {
                LblMarket.Text = "Market: " + market.Name;
            }
            else
            {
                LblMarket.Text = "Market: Not assigned";
            }
        }

        private void LoadProducts()
        {
            List<Product> products = _controller.GetProducts();

            ListProducts.Items.Clear();
            for (int i = 0; i < products.Count; i++)
            {
                ListProducts.Items.Add(products[i]);
            }
        }

        private void LoadCart()
        {
            var rawItems = _controller.GetCartItemsRaw();

            ListCart.Items.Clear();
            decimal total = 0;

            for (int i = 0; i < rawItems.Count; i++)
            {
                var item = rawItems[i];

                var vm = new CartItemViewModel
                {
                    ProductName = item.product.Name,
                    Quantity = item.quantity,
                    UnitPrice = item.product.Price
                };

                ListCart.Items.Add(vm);
                total += vm.Total;
            }

            LblTotal.Text = "Total: ₡" + total;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ListProducts.SelectedItem is not Product product)
            {
                return;
            }

            int quantity;
            if (!int.TryParse(TxtQuantity.Text, out quantity) || quantity <= 0)
            {
                quantity = 1;
            }

            _controller.AddItem(product, quantity);

            LoadProducts();
            LoadCart();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int index = ListCart.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            _controller.RemoveItemAt(index);

            LoadProducts();
            LoadCart();
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (!_controller.Checkout())
            {
                MessageBox.Show("Cart is empty.");
                return;
            }

            var rawItems = _controller.GetCartItemsRaw();
            var lines = new List<InvoiceLineViewModel>();
            decimal total = 0;

            for (int i = 0; i < rawItems.Count; i++)
            {
                var item = rawItems[i];
                decimal amount = item.product.Price * item.quantity;

                lines.Add(new InvoiceLineViewModel
                {
                    ProductName = item.product.Name,
                    Quantity = item.quantity,
                    Amount = amount
                });

                total += amount;
            }

            string marketName = _controller.GetMarket()?.Name ?? "Not assigned";

            var invoiceForm = new InvoiceForm(
                _controller.GetUserFullName(),
                marketName,
                lines,
                total);

            invoiceForm.Show();
            Hide();
        }
    }
}
