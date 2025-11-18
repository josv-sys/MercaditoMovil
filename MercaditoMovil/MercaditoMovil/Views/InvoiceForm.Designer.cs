namespace MercaditoMovil.Views.WinForms
{
    partial class InvoiceForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label LblCustomer;
        private System.Windows.Forms.Label LblMarket;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.ListBox ListItems;
        private System.Windows.Forms.Button BtnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            LblCustomer = new System.Windows.Forms.Label();
            LblMarket = new System.Windows.Forms.Label();
            LblTotal = new System.Windows.Forms.Label();
            ListItems = new System.Windows.Forms.ListBox();
            BtnClose = new System.Windows.Forms.Button();

            SuspendLayout();

            LblCustomer.Location = new System.Drawing.Point(20, 20);
            LblMarket.Location = new System.Drawing.Point(20, 50);
            LblTotal.Location = new System.Drawing.Point(20, 80);

            ListItems.Location = new System.Drawing.Point(20, 120);
            ListItems.Size = new System.Drawing.Size(350, 300);

            BtnClose.Text = "Close";
            BtnClose.Location = new System.Drawing.Point(20, 440);
            BtnClose.Click += BtnClose_Click;

            ClientSize = new System.Drawing.Size(400, 500);
            Controls.Add(LblCustomer);
            Controls.Add(LblMarket);
            Controls.Add(LblTotal);
            Controls.Add(ListItems);
            Controls.Add(BtnClose);

            Text = "Invoice";
            Load += InvoiceForm_Load;

            ResumeLayout(false);
        }
    }
}

