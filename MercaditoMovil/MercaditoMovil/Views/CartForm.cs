using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Views.WinForms.Controllers;
using MercaditoMovil.Views.WinForms.Models;

namespace MercaditoMovil.Views.WinForms
{
    /// <summary>
    /// Shopping cart form with product listing, filters and cart operations.
    /// </summary>
    public partial class CartForm : Form
    {
        private readonly CartController _controller = new CartController();
        private readonly User _currentUser;

        private List<Product> _allProducts = new List<Product>();
        private List<Product> _visibleProducts = new List<Product>();
        private List<CartItemViewModel> _cart = new List<CartItemViewModel>();

        public CartForm(User user)
        {
            InitializeComponent();
            _currentUser = user;

            LoadUserData();
            LoadProducers();
            LoadProducts();
            ApplyFilters();
        }

        /// <summary>
        /// Loads basic user and market information into labels.
        /// </summary>
        private void LoadUserData()
        {
            Market market = _controller.GetMarketById(_currentUser.MarketId);

            LblCustomer.Text = "Cliente: " +
                               _currentUser.FirstName + " " +
                               _currentUser.LastName1 + " " +
                               _currentUser.LastName2;

            if (market != null)
            {
                LblMarket.Text = "Feria: " + market.Name;
            }
            else
            {
                LblMarket.Text = "Feria: No asignada";
            }
        }

        /// <summary>
        /// Loads all producers for the filter ComboBox.
        /// </summary>
        private void LoadProducers()
        {
            List<Producer> producers = _controller.GetAllProducers();

            CmbProducerFilter.Items.Clear();
            CmbProducerFilter.Items.Add("Todos");

            for (int i = 0; i < producers.Count; i++)
            {
                CmbProducerFilter.Items.Add(producers[i].Name);
            }

            if (CmbProducerFilter.Items.Count > 0)
            {
                CmbProducerFilter.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Loads all products from repository.
        /// </summary>
        private void LoadProducts()
        {
            _allProducts = _controller.GetAllProducts();
        }

        /// <summary>
        /// Applies text and producer filters and refreshes the product ListView.
        /// </summary>
        private void ApplyFilters()
        {
            string textFilter = TxtSearch.Text.Trim().ToLower();
            string producerFilter = string.Empty;

            if (CmbProducerFilter.SelectedItem != null)
            {
                producerFilter = CmbProducerFilter.SelectedItem.ToString();
            }

            List<Product> filtered = new List<Product>();

            for (int i = 0; i < _allProducts.Count; i++)
            {
                Product p = _allProducts[i];

                // Filter by text
                if (textFilter != string.Empty &&
                    !p.Name.ToLower().Contains(textFilter))
                {
                    continue;
                }

                // Filter by producer
                if (!string.IsNullOrEmpty(producerFilter) &&
                    producerFilter != "Todos")
                {
                    Producer prod = _controller.GetProducerById(p.ProducerId);
                    if (prod == null || prod.Name != producerFilter)
                    {
                        continue;
                    }
                }

                filtered.Add(p);
            }

            RefreshProductList(filtered);
        }

        /// <summary>
        /// Refreshes the ListView of products.
        /// </summary>
        private void RefreshProductList(List<Product> products)
        {
            _visibleProducts = new List<Product>(products);
            LvProducts.Items.Clear();

            for (int i = 0; i < _visibleProducts.Count; i++)
            {
                Product p = _visibleProducts[i];

                ListViewItem item = new ListViewItem(p.Name);

                item.SubItems.Add("₡" + p.Price);
                item.SubItems.Add(p.Unit);
                item.SubItems.Add(p.Packaging);
                item.SubItems.Add(p.Stock.ToString());

                LvProducts.Items.Add(item);
            }
        }

        /// <summary>
        /// Handles text search filter.
        /// </summary>
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        /// <summary>
        /// Handles producer filter change.
        /// </summary>
        private void CmbProducerFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        /// <summary>
        /// Adds selected product to the cart with the chosen quantity.
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (LvProducts.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            int index = LvProducts.SelectedIndices[0];

            if (index < 0 || index >= _visibleProducts.Count)
            {
                MessageBox.Show("Seleccion invalida.");
                return;
            }

            Product p = _visibleProducts[index];
            int quantity = (int)NudCantidad.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.");
                return;
            }

            // Check if product is already in cart
            CartItemViewModel existing = null;

            for (int i = 0; i < _cart.Count; i++)
            {
                if (_cart[i].ProductName == p.Name)
                {
                    existing = _cart[i];
                    break;
                }
            }

            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                CartItemViewModel item = new CartItemViewModel();
                item.ProductName = p.Name;
                item.Quantity = quantity;
                item.UnitPrice = p.Price;

                _cart.Add(item);
            }

            RefreshCartList();
            UpdateTotal();

            NudCantidad.Value = 1;
        }

        /// <summary>
        /// Refreshes the cart ListView.
        /// </summary>
        private void RefreshCartList()
        {
            LvCart.Items.Clear();

            for (int i = 0; i < _cart.Count; i++)
            {
                CartItemViewModel item = _cart[i];

                ListViewItem row = new ListViewItem(item.ProductName);
                row.SubItems.Add(item.Quantity.ToString());
                row.SubItems.Add("₡" + item.UnitPrice);
                row.SubItems.Add("₡" + item.Total);

                LvCart.Items.Add(row);
            }
        }

        /// <summary>
        /// Updates total label based on cart items.
        /// </summary>
        private void UpdateTotal()
        {
            decimal sum = 0;

            for (int i = 0; i < _cart.Count; i++)
            {
                sum += _cart[i].Total;
            }

            LblTotal.Text = "Total: ₡" + sum;
        }

        /// <summary>
        /// Removes selected item from cart.
        /// </summary>
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (LvCart.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccione un item del carrito.");
                return;
            }

            int index = LvCart.SelectedIndices[0];

            if (index < 0 || index >= _cart.Count)
            {
                MessageBox.Show("Seleccion invalida.");
                return;
            }

            _cart.RemoveAt(index);

            RefreshCartList();
            UpdateTotal();
        }

        /// <summary>
        /// Generates invoice and opens InvoiceForm.
        /// In next iteration this will also update inventory.
        /// </summary>
        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("No hay productos en el carrito.");
                return;
            }

            string paymentMethod = RbSinpe.Checked ? "SINPE Movil" : "Efectivo";

            _controller.SaveInvoice(_currentUser, _cart, paymentMethod);

            InvoiceForm invoiceForm = new InvoiceForm(_currentUser, _cart, paymentMethod);
            invoiceForm.ShowDialog();

            // Optionally clear cart after invoicing
            // _cart.Clear();
            // RefreshCartList();
            // UpdateTotal();
        }
    }
}
