namespace MercaditoMovil.Views.WinForms
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label LblCustomer;
        private System.Windows.Forms.Label LblMarket;
        private System.Windows.Forms.ListBox ListProducts;
        private System.Windows.Forms.ListBox ListCart;
        private System.Windows.Forms.TextBox TxtQuantity;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnCheckout;
        private System.Windows.Forms.Label LblTotal;

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
            ListProducts = new System.Windows.Forms.ListBox();
            ListCart = new System.Windows.Forms.ListBox();
            TxtQuantity = new System.Windows.Forms.TextBox();
            BtnAdd = new System.Windows.Forms.Button();
            BtnRemove = new System.Windows.Forms.Button();
            BtnCheckout = new System.Windows.Forms.Button();
            LblTotal = new System.Windows.Forms.Label();

            SuspendLayout();

            LblCustomer.Location = new System.Drawing.Point(20, 20);
            LblMarket.Location = new System.Drawing.Point(20, 50);

            ListProducts.Location = new System.Drawing.Point(20, 90);
            ListProducts.Size = new System.Drawing.Size(250, 300);

            ListCart.Location = new System.Drawing.Point(300, 90);
            ListCart.Size = new System.Drawing.Size(250, 300);

            TxtQuantity.Location = new System.Drawing.Point(20, 400);
            TxtQuantity.Size = new System.Drawing.Size(80, 23);

            BtnAdd.Text = "Add";
            BtnAdd.Location = new System.Drawing.Point(120, 400);
            BtnAdd.Click += BtnAdd_Click;

            BtnRemove.Text = "Remove";
            BtnRemove.Location = new System.Drawing.Point(300, 400);
            BtnRemove.Click += BtnRemove_Click;

            BtnCheckout.Text = "Checkout";
            BtnCheckout.Location = new System.Drawing.Point(300, 450);
            BtnCheckout.Click += BtnCheckout_Click;

            LblTotal.Location = new System.Drawing.Point(300, 420);

            ClientSize = new System.Drawing.Size(600, 520);
            Controls.Add(LblCustomer);
            Controls.Add(LblMarket);
            Controls.Add(ListProducts);
            Controls.Add(ListCart);
            Controls.Add(TxtQuantity);
            Controls.Add(BtnAdd);
            Controls.Add(BtnRemove);
            Controls.Add(BtnCheckout);
            Controls.Add(LblTotal);

            Text = "Cart";
            ResumeLayout(false);
        }
    }
}
