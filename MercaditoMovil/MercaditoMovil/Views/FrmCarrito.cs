using System;
using System.Linq;
using System.Windows.Forms;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Views.WinForms.Controllers;
using ReaLTaiizor.Child.Material;
using ReaLTaiizor.Forms;

namespace MercaditoMovil.Views.WinForms
{
    public partial class FrmCarrito : MaterialForm
    {
        private readonly FrmCarritoController _controller;

        public FrmCarrito(Usuario usuario)
        {
            InitializeComponent();
            _controller = new FrmCarritoController(usuario);

            // MUY IMPORTANTE
            this.Load += FrmCarrito_Load;
        }

        private void FrmCarrito_Load(object sender, EventArgs e)
        {
            CargarFeria();
            CargarProductos();
            ActualizarTotal();
        }

        private void CargarFeria()
        {
            var feria = _controller.ObtenerFeria();

            ComboFerias.Items.Clear();
            ComboFerias.SelectedIndex = -1;

            if (feria != null)
            {
                ComboFerias.Items.Add($"{feria.MarketId} - {feria.MarketName}");
                ComboFerias.SelectedIndex = 0;
            }
            else
            {
                ComboFerias.Items.Add("No asignada");
                ComboFerias.SelectedIndex = 0;
            }
        }

        private void CargarProductos()
        {
            ListaProductos.Items.Clear();

            var productos = _controller.ObtenerProductos();

            foreach (var p in productos)
            {
                string stockText = p.Stock > 0 ? p.Stock.ToString() : "AGOTADO";

                ListaProductos.Items.Add(new MaterialListBoxItem
                {
                    Text = $"{p.Nombre} - ₡{p.Precio:N0} - Stock:{stockText} - Empaque:{p.Packaging}",
                    Tag = p
                });
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ListaProductos.SelectedItem is not MaterialListBoxItem item ||
                item.Tag is not Producto prod)
                return;

            int cantidad;
            if (!int.TryParse(TxtCantidad.Text, out cantidad) || cantidad <= 0)
                cantidad = 1;

            if (prod.Stock <= 0)
            {
                MessageBox.Show("Producto agotado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (prod.Stock < cantidad)
            {
                MessageBox.Show("No hay suficiente stock.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _controller.Agregar(prod, cantidad);

            ListaCarrito.Items.Add(new MaterialListBoxItem
            {
                Text = $"{prod.Nombre} x{cantidad} - ₡{(prod.Precio * cantidad):N0}",
                Tag = (prod, cantidad)
            });

            CargarProductos();
            ActualizarTotal();
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (ListaCarrito.SelectedItem is not MaterialListBoxItem item ||
                item.Tag is not ValueTuple<Producto, int> tupla)
                return;

            _controller.Quitar(tupla);
            ListaCarrito.Items.Remove(item);

            CargarProductos();
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            var carrito = _controller.ObtenerCarrito();

            decimal total = carrito.Sum(i => i.producto.Precio * i.cantidad);
            LblTotal.Text = $"Total: ₡{total:N0}";
        }

        private void BtnGenerarFactura_Click(object sender, EventArgs e)
        {
            var carrito = _controller.ObtenerCarrito();

            if (carrito.Count == 0)
            {
                MessageBox.Show("No hay productos en el carrito.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var detalle = carrito
                .GroupBy(i => i.producto.Nombre)
                .Select(g => (
                    Producto: g.Key,
                    Cantidad: g.Sum(x => x.cantidad),
                    Precio: g.Sum(x => x.producto.Precio * x.cantidad)
                ))
                .ToList();

            decimal total = detalle.Sum(d => d.Precio);
            string feria = _controller.ObtenerFeria()?.MarketName ?? "Feria no asignada";

            // Guardar compra en CSV
            _controller.FinalizarCompra();

            // Abrir factura
            FrmFactura frm = new FrmFactura(
                _controller.Usuario.Nombre,
                feria,
                detalle,
                total);

            frm.Show();
            this.Hide();
        }
    }
}
