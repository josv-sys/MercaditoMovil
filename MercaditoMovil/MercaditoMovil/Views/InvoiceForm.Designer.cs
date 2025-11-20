namespace MercaditoMovil.Views.WinForms.Views
{
    partial class InvoiceForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label LblMarket;
        private System.Windows.Forms.Label LblPayment;
        private System.Windows.Forms.ListBox ListInvoice;

        private System.Windows.Forms.Label LblSubtotal;
        private System.Windows.Forms.Label LblTax;
        private System.Windows.Forms.Label LblService;
        private System.Windows.Forms.Label LblTotal;

        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Button BtnBack;

        /// <summary>
        /// Disposes resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes form controls and layout.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            System.Drawing.Color bg = System.Drawing.Color.FromArgb(245, 238, 230);
            System.Drawing.Color panel = System.Drawing.Color.FromArgb(220, 205, 190);
            System.Drawing.Color accent = System.Drawing.Color.FromArgb(160, 120, 80);
            System.Drawing.Color text = System.Drawing.Color.FromArgb(80, 60, 50);

            this.BackColor = bg;
            this.ClientSize = new System.Drawing.Size(600, 620);
            this.Text = "Factura";

            // LblUser
            LblUser = new System.Windows.Forms.Label();
            LblUser.Location = new System.Drawing.Point(20, 20);
            LblUser.AutoSize = true;
            LblUser.ForeColor = text;

            // LblMarket
            LblMarket = new System.Windows.Forms.Label();
            LblMarket.Location = new System.Drawing.Point(20, 45);
            LblMarket.AutoSize = true;
            LblMarket.ForeColor = text;

            // LblPayment
            LblPayment = new System.Windows.Forms.Label();
            LblPayment.Location = new System.Drawing.Point(20, 70);
            LblPayment.AutoSize = true;
            LblPayment.ForeColor = text;

            // ListInvoice
            ListInvoice = new System.Windows.Forms.ListBox();
            ListInvoice.Location = new System.Drawing.Point(20, 110);
            ListInvoice.Size = new System.Drawing.Size(550, 330);
            ListInvoice.BackColor = panel;
            ListInvoice.ForeColor = text;

            // LblSubtotal
            LblSubtotal = new System.Windows.Forms.Label();
            LblSubtotal.Location = new System.Drawing.Point(20, 460);
            LblSubtotal.AutoSize = true;
            LblSubtotal.ForeColor = text;

            // LblTax
            LblTax = new System.Windows.Forms.Label();
            LblTax.Location = new System.Drawing.Point(20, 485);
            LblTax.AutoSize = true;
            LblTax.ForeColor = text;

            // LblService
            LblService = new System.Windows.Forms.Label();
            LblService.Location = new System.Drawing.Point(20, 510);
            LblService.AutoSize = true;
            LblService.ForeColor = text;

            // LblTotal
            LblTotal = new System.Windows.Forms.Label();
            LblTotal.Location = new System.Drawing.Point(20, 535);
            LblTotal.AutoSize = true;
            LblTotal.ForeColor = text;

            // BtnBack
            BtnBack = new System.Windows.Forms.Button();
            BtnBack.Text = "Volver";
            BtnBack.Location = new System.Drawing.Point(20, 560);
            BtnBack.Size = new System.Drawing.Size(120, 30);
            BtnBack.BackColor = accent;
            BtnBack.ForeColor = System.Drawing.Color.White;
            BtnBack.Click += BtnBack_Click;

            // BtnConfirm
            BtnConfirm = new System.Windows.Forms.Button();
            BtnConfirm.Text = "Confirmar compra";
            BtnConfirm.Location = new System.Drawing.Point(450, 560);
            BtnConfirm.Size = new System.Drawing.Size(120, 30);
            BtnConfirm.BackColor = accent;
            BtnConfirm.ForeColor = System.Drawing.Color.White;
            BtnConfirm.Click += BtnConfirm_Click;

            Controls.Add(LblUser);
            Controls.Add(LblMarket);
            Controls.Add(LblPayment);
            Controls.Add(ListInvoice);
            Controls.Add(LblSubtotal);
            Controls.Add(LblTax);
            Controls.Add(LblService);
            Controls.Add(LblTotal);
            Controls.Add(BtnBack);
            Controls.Add(BtnConfirm);
        }
    }
}
