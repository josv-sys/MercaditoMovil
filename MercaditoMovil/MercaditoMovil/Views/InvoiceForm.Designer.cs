namespace MercaditoMovil.Views.WinForms
{
    partial class InvoiceForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label LblCustomer;
        private System.Windows.Forms.Label LblPayment;
        private System.Windows.Forms.ListBox ListInvoice;
        private System.Windows.Forms.Label LblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.BackColor = System.Drawing.Color.FromArgb(245, 238, 230);

            LblCustomer = new System.Windows.Forms.Label();
            LblPayment = new System.Windows.Forms.Label();
            ListInvoice = new System.Windows.Forms.ListBox();
            LblTotal = new System.Windows.Forms.Label();

            SuspendLayout();

            LblCustomer.AutoSize = true;
            LblCustomer.Location = new System.Drawing.Point(20, 20);

            LblPayment.AutoSize = true;
            LblPayment.Location = new System.Drawing.Point(20, 45);

            ListInvoice.Location = new System.Drawing.Point(20, 80);
            ListInvoice.Size = new System.Drawing.Size(350, 300);
            ListInvoice.BackColor = System.Drawing.Color.FromArgb(220, 205, 190);

            LblTotal.AutoSize = true;
            LblTotal.Location = new System.Drawing.Point(20, 400);

            ClientSize = new System.Drawing.Size(400, 450);
            Controls.Add(LblCustomer);
            Controls.Add(LblPayment);
            Controls.Add(ListInvoice);
            Controls.Add(LblTotal);

            Text = "Factura";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
