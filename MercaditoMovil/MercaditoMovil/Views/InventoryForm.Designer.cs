namespace MercaditoMovil.Views.WinForms
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.ListView LvInventory;
        private System.Windows.Forms.ColumnHeader ColInvCatalogId;
        private System.Windows.Forms.ColumnHeader ColInvName;
        private System.Windows.Forms.ColumnHeader ColInvProducerId;
        private System.Windows.Forms.ColumnHeader ColInvUnit;
        private System.Windows.Forms.ColumnHeader ColInvPack;
        private System.Windows.Forms.ColumnHeader ColInvPrice;
        private System.Windows.Forms.ColumnHeader ColInvStock;
        private System.Windows.Forms.Button BtnRefresh;

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

            // Title
            LblTitle = new System.Windows.Forms.Label();
            LblTitle.AutoSize = true;
            LblTitle.Text = "Inventario de productos";
            LblTitle.Location = new System.Drawing.Point(20, 20);
            LblTitle.ForeColor = text;

            // ListView Inventory
            LvInventory = new System.Windows.Forms.ListView();
            LvInventory.Location = new System.Drawing.Point(20, 55);
            LvInventory.Size = new System.Drawing.Size(740, 360);
            LvInventory.View = System.Windows.Forms.View.Details;
            LvInventory.FullRowSelect = true;
            LvInventory.HideSelection = false;
            LvInventory.BackColor = panel;
            LvInventory.ForeColor = text;

            ColInvCatalogId = new System.Windows.Forms.ColumnHeader() { Text = "Catalogo", Width = 90 };
            ColInvName = new System.Windows.Forms.ColumnHeader() { Text = "Producto", Width = 140 };
            ColInvProducerId = new System.Windows.Forms.ColumnHeader() { Text = "Productor", Width = 90 };
            ColInvUnit = new System.Windows.Forms.ColumnHeader() { Text = "Unidad", Width = 80 };
            ColInvPack = new System.Windows.Forms.ColumnHeader() { Text = "Empaque", Width = 100 };
            ColInvPrice = new System.Windows.Forms.ColumnHeader() { Text = "Precio", Width = 80 };
            ColInvStock = new System.Windows.Forms.ColumnHeader() { Text = "Stock", Width = 70 };

            LvInventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
            {
                ColInvCatalogId, ColInvName, ColInvProducerId,
                ColInvUnit, ColInvPack, ColInvPrice, ColInvStock
            });

            // Refresh button
            BtnRefresh = new System.Windows.Forms.Button();
            BtnRefresh.Text = "Actualizar";
            BtnRefresh.Location = new System.Drawing.Point(20, 430);
            BtnRefresh.Size = new System.Drawing.Size(110, 30);
            BtnRefresh.BackColor = accent;
            BtnRefresh.ForeColor = System.Drawing.Color.White;
            BtnRefresh.Click += BtnRefresh_Click;

            // Form
            this.ClientSize = new System.Drawing.Size(790, 480);
            this.Controls.Add(LblTitle);
            this.Controls.Add(LvInventory);
            this.Controls.Add(BtnRefresh);
            this.Text = "Inventario";
        }
    }
}
