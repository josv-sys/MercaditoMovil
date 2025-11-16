using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ReaLTaiizor.Child.Material;
using ReaLTaiizor.Forms;

namespace MercaditoMovil.Views.WinForms
{
    public partial class FrmFactura : MaterialForm
    {
        private List<(string Producto, int Cantidad, decimal Precio)> _detalle;

        public FrmFactura(
            string nombreCliente,
            string feria,
            List<(string Producto, int Cantidad, decimal Precio)> detalle,
            decimal total)
        {
            InitializeComponent();

            _detalle = detalle;

            // Datos del encabezado
            LblNombreCliente.Text = $"Cliente: {nombreCliente}";
            LblFeria.Text = $"Feria: {feria}";
            LblTotal.Text = $"TOTAL A PAGAR: ₡{total:N0}";

            CargarDetalle();
        }

        private void CargarDetalle()
        {
            ListaDetalle.Items.Clear();

            foreach (var d in _detalle)
            {
                ListaDetalle.Items.Add(new MaterialListBoxItem
                {
                    Text = $"{d.Producto}   x{d.Cantidad}   - ₡{d.Precio:N0}"
                });
            }
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            if (ComboPago.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un método de pago.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string metodo = ComboPago.SelectedItem.ToString();

            MessageBox.Show($"Pago realizado con {metodo}.",
                "Compra Completada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }
    }
}








