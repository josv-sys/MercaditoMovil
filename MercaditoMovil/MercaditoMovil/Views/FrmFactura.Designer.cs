namespace MercaditoMovil.Views.WinForms
{
    partial class FrmFactura
    {
        private System.ComponentModel.IContainer components = null;
        private ReaLTaiizor.Controls.MaterialLabel LblNombreCliente;
        private ReaLTaiizor.Controls.MaterialLabel LblFeria;
        private ReaLTaiizor.Controls.MaterialLabel LblTotal;
        private ReaLTaiizor.Controls.MaterialListBox ListaDetalle;
        private ReaLTaiizor.Controls.MaterialComboBox ComboPago;
        private ReaLTaiizor.Controls.MaterialButton BtnPagar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LblNombreCliente = new ReaLTaiizor.Controls.MaterialLabel();
            this.LblFeria = new ReaLTaiizor.Controls.MaterialLabel();
            this.LblTotal = new ReaLTaiizor.Controls.MaterialLabel();
            this.ListaDetalle = new ReaLTaiizor.Controls.MaterialListBox();
            this.ComboPago = new ReaLTaiizor.Controls.MaterialComboBox();
            this.BtnPagar = new ReaLTaiizor.Controls.MaterialButton();

            this.SuspendLayout();

            // ========= FORM =========
            this.ClientSize = new System.Drawing.Size(720, 680);
            this.Text = "Factura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(32, 33, 36);

            // ========= LblNombreCliente =========
            this.LblNombreCliente.Location = new System.Drawing.Point(30, 90);
            this.LblNombreCliente.Size = new System.Drawing.Size(650, 40);
            this.LblNombreCliente.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Bold);
            this.LblNombreCliente.ForeColor = System.Drawing.Color.White;
            this.LblNombreCliente.Text = "Cliente:";

            // ========= LblFeria =========
            this.LblFeria.Location = new System.Drawing.Point(30, 140);
            this.LblFeria.Size = new System.Drawing.Size(650, 30);
            this.LblFeria.Font = new System.Drawing.Font("Poppins", 13F);
            this.LblFeria.ForeColor = System.Drawing.Color.Gainsboro;
            this.LblFeria.Text = "Feria:";

            // ========= ListaDetalle =========
            this.ListaDetalle.Location = new System.Drawing.Point(30, 190);
            this.ListaDetalle.Size = new System.Drawing.Size(660, 330);
            this.ListaDetalle.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.ListaDetalle.ForeColor = System.Drawing.Color.WhiteSmoke;

            // ========= LblTotal =========
            this.LblTotal.Location = new System.Drawing.Point(30, 540);
            this.LblTotal.Size = new System.Drawing.Size(650, 50);
            this.LblTotal.Font = new System.Drawing.Font("Poppins", 21F, System.Drawing.FontStyle.Bold);
            this.LblTotal.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.LblTotal.Text = "TOTAL:";

            // ========= ComboPago =========
            this.ComboPago.Location = new System.Drawing.Point(30, 600);
            this.ComboPago.Size = new System.Drawing.Size(300, 50);
            this.ComboPago.Font = new System.Drawing.Font("Poppins", 12F);
            this.ComboPago.Items.Add("Efectivo");
            this.ComboPago.Items.Add("SINPE Móvil");
            this.ComboPago.Hint = "Método de pago";
            this.ComboPago.StartIndex = 0;

            // ========= BtnPagar =========
            this.BtnPagar.Location = new System.Drawing.Point(360, 600);
            this.BtnPagar.Size = new System.Drawing.Size(200, 50);
            this.BtnPagar.Text = "Pagar";
            this.BtnPagar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnPagar.Click += new System.EventHandler(this.BtnPagar_Click);

            // ========= Añadir controles =========
            this.Controls.Add(this.LblNombreCliente);
            this.Controls.Add(this.LblFeria);
            this.Controls.Add(this.ListaDetalle);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.ComboPago);
            this.Controls.Add(this.BtnPagar);

            this.ResumeLayout(false);
        }
    }
}


