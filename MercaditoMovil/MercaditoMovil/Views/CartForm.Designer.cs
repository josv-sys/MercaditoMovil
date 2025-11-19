namespace MercaditoMovil.Views.WinForms
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label LblCustomer;
        private System.Windows.Forms.Label LblMarket;

        private System.Windows.Forms.Label LblProducerFilter;
        private System.Windows.Forms.ComboBox CmbProducerFilter;

        private System.Windows.Forms.Label LblSearch;
        private System.Windows.Forms.TextBox TxtSearch;

        private System.Windows.Forms.ListView LvProducts;
        private System.Windows.Forms.ListView LvCart;

        private System.Windows.Forms.ColumnHeader ColProdName;
        private System.Windows.Forms.ColumnHeader ColProdPrice;
        private System.Windows.Forms.ColumnHeader ColProdUnit;
        private System.Windows.Forms.ColumnHeader ColProdPack;

        private System.Windows.Forms.ColumnHeader ColCartName;
        private System.Windows.Forms.ColumnHeader ColCartQty;
        private System.Windows.Forms.ColumnHeader ColCartPrice;
        private System.Windows.Forms.ColumnHeader ColCartTotal;

        private System.Windows.Forms.NumericUpDown NudCantidad;

        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRemove;

        private System.Windows.Forms.Label LblPayment;
        private System.Windows.Forms.RadioButton RbSinpe;
        private System.Windows.Forms.RadioButton RbCash;

        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Button BtnCheckout;
        private System.Windows.Forms.Button BtnInventory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            System.Drawing.Color bg = System.Drawing.Color.FromArgb(245, 238, 230);
            System.Drawing.Color panel = System.Drawing.Color.FromArgb(220, 205, 190);
            System.Drawing.Color text = System.Drawing.Color.FromArgb(80, 60, 50);
            System.Drawing.Color accent = System.Drawing.Color.FromArgb(160, 120, 80);

            this.BackColor = bg;

            // ======== Etiquetas de usuario y mercado ========
            LblCustomer = new System.Windows.Forms.Label();
            LblCustomer.Location = new System.Drawing.Point(20, 20);
            LblCustomer.AutoSize = true;
            LblCustomer.ForeColor = text;

            LblMarket = new System.Windows.Forms.Label();
            LblMarket.Location = new System.Drawing.Point(20, 45);
            LblMarket.AutoSize = true;
            LblMarket.ForeColor = text;

            // ======== Filtro de productor ========
            LblProducerFilter = new System.Windows.Forms.Label();
            LblProducerFilter.Text = "Filtrar por productor:";
            LblProducerFilter.Location = new System.Drawing.Point(20, 85);
            LblProducerFilter.AutoSize = true;
            LblProducerFilter.ForeColor = text;

            CmbProducerFilter = new System.Windows.Forms.ComboBox();
            CmbProducerFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbProducerFilter.Location = new System.Drawing.Point(20, 105);
            CmbProducerFilter.Size = new System.Drawing.Size(270, 23);
            CmbProducerFilter.SelectedIndexChanged += CmbProducerFilter_SelectedIndexChanged;

            // ======== Buscador ========
            LblSearch = new System.Windows.Forms.Label();
            LblSearch.Text = "Buscar producto:";
            LblSearch.Location = new System.Drawing.Point(20, 140);
            LblSearch.AutoSize = true;
            LblSearch.ForeColor = text;

            TxtSearch = new System.Windows.Forms.TextBox();
            TxtSearch.Location = new System.Drawing.Point(20, 160);
            TxtSearch.Size = new System.Drawing.Size(270, 23);
            TxtSearch.TextChanged += TxtSearch_TextChanged;

            // ======== ListView de productos ========
            LvProducts = new System.Windows.Forms.ListView();
            LvProducts.Location = new System.Drawing.Point(20, 200);
            LvProducts.Size = new System.Drawing.Size(450, 350);
            LvProducts.View = System.Windows.Forms.View.Details;
            LvProducts.FullRowSelect = true;
            LvProducts.HideSelection = false;
            LvProducts.BackColor = panel;
            LvProducts.ForeColor = text;

            ColProdName = new System.Windows.Forms.ColumnHeader() { Text = "Producto", Width = 150 };
            ColProdPrice = new System.Windows.Forms.ColumnHeader() { Text = "Precio", Width = 80 };
            ColProdUnit = new System.Windows.Forms.ColumnHeader() { Text = "Unidad", Width = 80 };
            ColProdPack = new System.Windows.Forms.ColumnHeader() { Text = "Empaque", Width = 120 };

            LvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
            {
                ColProdName, ColProdPrice, ColProdUnit, ColProdPack
            });

            // ======== Selector de cantidad ========
            NudCantidad = new System.Windows.Forms.NumericUpDown();
            NudCantidad.Location = new System.Drawing.Point(20, 560);
            NudCantidad.Minimum = 1;
            NudCantidad.Maximum = 999;
            NudCantidad.Value = 1;
            NudCantidad.Width = 60;

            // ======== Botón Agregar ========
            BtnAdd = new System.Windows.Forms.Button();
            BtnAdd.Text = "Agregar";
            BtnAdd.Location = new System.Drawing.Point(100, 557);
            BtnAdd.Size = new System.Drawing.Size(120, 30);
            BtnAdd.BackColor = accent;
            BtnAdd.ForeColor = System.Drawing.Color.White;
            BtnAdd.Click += BtnAdd_Click;

            // ======== ListView del carrito ========
            LvCart = new System.Windows.Forms.ListView();
            LvCart.Location = new System.Drawing.Point(500, 105);
            LvCart.Size = new System.Drawing.Size(450, 350);
            LvCart.View = System.Windows.Forms.View.Details;
            LvCart.FullRowSelect = true;
            LvCart.HideSelection = false;
            LvCart.BackColor = panel;
            LvCart.ForeColor = text;

            ColCartName = new System.Windows.Forms.ColumnHeader() { Text = "Producto", Width = 150 };
            ColCartQty = new System.Windows.Forms.ColumnHeader() { Text = "Cant", Width = 60 };
            ColCartPrice = new System.Windows.Forms.ColumnHeader() { Text = "Precio", Width = 80 };
            ColCartTotal = new System.Windows.Forms.ColumnHeader() { Text = "Total", Width = 100 };

            LvCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
            {
                ColCartName, ColCartQty, ColCartPrice, ColCartTotal
            });

            // ======== Botón Quitar ========
            BtnRemove = new System.Windows.Forms.Button();
            BtnRemove.Text = "Quitar";
            BtnRemove.Location = new System.Drawing.Point(500, 460);
            BtnRemove.Size = new System.Drawing.Size(120, 30);
            BtnRemove.BackColor = accent;
            BtnRemove.ForeColor = System.Drawing.Color.White;
            BtnRemove.Click += BtnRemove_Click;

            // ======== Pago ========
            LblPayment = new System.Windows.Forms.Label();
            LblPayment.Text = "Metodo de pago:";
            LblPayment.Location = new System.Drawing.Point(500, 20);
            LblPayment.AutoSize = true;
            LblPayment.ForeColor = text;

            RbSinpe = new System.Windows.Forms.RadioButton();
            RbSinpe.Text = "SINPE movil";
            RbSinpe.Location = new System.Drawing.Point(500, 45);
            RbSinpe.ForeColor = text;
            RbSinpe.Checked = true;

            RbCash = new System.Windows.Forms.RadioButton();
            RbCash.Text = "Efectivo";
            RbCash.Location = new System.Drawing.Point(500, 70);
            RbCash.ForeColor = text;

            // ======== Total ========
            LblTotal = new System.Windows.Forms.Label();
            LblTotal.Location = new System.Drawing.Point(500, 500);
            LblTotal.Text = "Total: ₡0";
            LblTotal.AutoSize = true;
            LblTotal.ForeColor = text;

            // ======== Botón Facturar ========
            BtnCheckout = new System.Windows.Forms.Button();
            BtnCheckout.Text = "Facturar";
            BtnCheckout.Location = new System.Drawing.Point(500, 530);
            BtnCheckout.Size = new System.Drawing.Size(120, 30);
            BtnCheckout.BackColor = accent;
            BtnCheckout.ForeColor = System.Drawing.Color.White;
            BtnCheckout.Click += BtnCheckout_Click;

            // ======== Botón Inventario ========
            BtnInventory = new System.Windows.Forms.Button();
            BtnInventory.Text = "Ver inventario";
            BtnInventory.Location = new System.Drawing.Point(630, 530);
            BtnInventory.Size = new System.Drawing.Size(120, 30);
            BtnInventory.BackColor = accent;
            BtnInventory.ForeColor = System.Drawing.Color.White;
            BtnInventory.Click += BtnInventory_Click;

            // ======== Form ========
            ClientSize = new System.Drawing.Size(980, 620);
            Controls.Add(LblCustomer);
            Controls.Add(LblMarket);
            Controls.Add(LblProducerFilter);
            Controls.Add(CmbProducerFilter);
            Controls.Add(LblSearch);
            Controls.Add(TxtSearch);
            Controls.Add(LvProducts);
            Controls.Add(NudCantidad);
            Controls.Add(BtnAdd);
            Controls.Add(LvCart);
            Controls.Add(BtnRemove);
            Controls.Add(LblPayment);
            Controls.Add(RbSinpe);
            Controls.Add(RbCash);
            Controls.Add(LblTotal);
            Controls.Add(BtnCheckout);
            Controls.Add(BtnInventory);

            Text = "Carrito de Compras";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

