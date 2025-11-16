namespace MercaditoMovil.Views.WinForms
{
    partial class FrmCarrito
    {
        private System.ComponentModel.IContainer components = null;

        private ReaLTaiizor.Controls.MaterialLabel LblNombreCliente;
        private ReaLTaiizor.Controls.MaterialLabel LblFeria;
        private ReaLTaiizor.Controls.MaterialLabel LblTotal;

        private ReaLTaiizor.Controls.MaterialListBox ListaProductos;
        private ReaLTaiizor.Controls.MaterialListBox ListaCarrito;

        private ReaLTaiizor.Controls.MaterialTextBoxEdit TxtCantidad;

        private ReaLTaiizor.Controls.MaterialButton BtnAgregar;
        private ReaLTaiizor.Controls.MaterialButton BtnQuitar;
        private ReaLTaiizor.Controls.MaterialButton BtnGenerarFactura;

        private ReaLTaiizor.Controls.MaterialComboBox ComboFerias;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            LblNombreCliente = new ReaLTaiizor.Controls.MaterialLabel();
            LblFeria = new ReaLTaiizor.Controls.MaterialLabel();
            ComboFerias = new ReaLTaiizor.Controls.MaterialComboBox();
            ListaProductos = new ReaLTaiizor.Controls.MaterialListBox();
            TxtCantidad = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            BtnAgregar = new ReaLTaiizor.Controls.MaterialButton();
            ListaCarrito = new ReaLTaiizor.Controls.MaterialListBox();
            BtnQuitar = new ReaLTaiizor.Controls.MaterialButton();
            LblTotal = new ReaLTaiizor.Controls.MaterialLabel();
            BtnGenerarFactura = new ReaLTaiizor.Controls.MaterialButton();
            SuspendLayout();
            // 
            // LblNombreCliente
            // 
            LblNombreCliente.Depth = 0;
            LblNombreCliente.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblNombreCliente.ForeColor = Color.White;
            LblNombreCliente.Location = new Point(40, 80);
            LblNombreCliente.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            LblNombreCliente.Name = "LblNombreCliente";
            LblNombreCliente.Size = new Size(248, 23);
            LblNombreCliente.TabIndex = 0;
            LblNombreCliente.Text = "Cliente:";
            // 
            // LblFeria
            // 
            LblFeria.Depth = 0;
            LblFeria.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblFeria.ForeColor = Color.LightGray;
            LblFeria.Location = new Point(40, 120);
            LblFeria.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            LblFeria.Name = "LblFeria";
            LblFeria.Size = new Size(277, 37);
            LblFeria.TabIndex = 1;
            LblFeria.Text = "Feria:";
            // 
            // ComboFerias
            // 
            ComboFerias.AutoResize = false;
            ComboFerias.BackColor = Color.FromArgb(255, 255, 255);
            ComboFerias.Depth = 0;
            ComboFerias.DrawMode = DrawMode.OwnerDrawVariable;
            ComboFerias.DropDownHeight = 174;
            ComboFerias.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboFerias.DropDownWidth = 121;
            ComboFerias.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            ComboFerias.ForeColor = Color.Black;
            ComboFerias.IntegralHeight = false;
            ComboFerias.ItemHeight = 43;
            ComboFerias.Location = new Point(40, 160);
            ComboFerias.MaxDropDownItems = 4;
            ComboFerias.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            ComboFerias.Name = "ComboFerias";
            ComboFerias.Size = new Size(300, 49);
            ComboFerias.StartIndex = 0;
            ComboFerias.TabIndex = 2;
            // 
            // ListaProductos
            // 
            ListaProductos.BackColor = Color.FromArgb(35, 35, 35);
            ListaProductos.BorderColor = Color.LightGray;
            ListaProductos.Depth = 0;
            ListaProductos.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ListaProductos.Location = new Point(40, 220);
            ListaProductos.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ListaProductos.Name = "ListaProductos";
            ListaProductos.SelectedIndex = -1;
            ListaProductos.SelectedItem = null;
            ListaProductos.Size = new Size(420, 380);
            ListaProductos.TabIndex = 3;
            // 
            // TxtCantidad
            // 
            TxtCantidad.AnimateReadOnly = false;
            TxtCantidad.AutoCompleteMode = AutoCompleteMode.None;
            TxtCantidad.AutoCompleteSource = AutoCompleteSource.None;
            TxtCantidad.BackgroundImageLayout = ImageLayout.None;
            TxtCantidad.CharacterCasing = CharacterCasing.Normal;
            TxtCantidad.Depth = 0;
            TxtCantidad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtCantidad.HideSelection = true;
            TxtCantidad.LeadingIcon = null;
            TxtCantidad.Location = new Point(480, 220);
            TxtCantidad.MaxLength = 32767;
            TxtCantidad.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            TxtCantidad.Name = "TxtCantidad";
            TxtCantidad.PasswordChar = '\0';
            TxtCantidad.PrefixSuffixText = null;
            TxtCantidad.ReadOnly = false;
            TxtCantidad.RightToLeft = RightToLeft.No;
            TxtCantidad.SelectedText = "";
            TxtCantidad.SelectionLength = 0;
            TxtCantidad.SelectionStart = 0;
            TxtCantidad.ShortcutsEnabled = true;
            TxtCantidad.Size = new Size(150, 48);
            TxtCantidad.TabIndex = 4;
            TxtCantidad.TabStop = false;
            TxtCantidad.Text = "1";
            TxtCantidad.TextAlign = HorizontalAlignment.Left;
            TxtCantidad.TrailingIcon = null;
            TxtCantidad.UseSystemPasswordChar = false;
            // 
            // BtnAgregar
            // 
            BtnAgregar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnAgregar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnAgregar.Depth = 0;
            BtnAgregar.HighEmphasis = true;
            BtnAgregar.Icon = null;
            BtnAgregar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            BtnAgregar.Location = new Point(480, 280);
            BtnAgregar.Margin = new Padding(4, 6, 4, 6);
            BtnAgregar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.NoAccentTextColor = Color.Empty;
            BtnAgregar.Size = new Size(88, 36);
            BtnAgregar.TabIndex = 5;
            BtnAgregar.Text = "Agregar";
            BtnAgregar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnAgregar.UseAccentColor = false;
            BtnAgregar.Click += BtnAgregar_Click;
            // 
            // ListaCarrito
            // 
            ListaCarrito.BackColor = Color.FromArgb(40, 40, 40);
            ListaCarrito.BorderColor = Color.LightGray;
            ListaCarrito.Depth = 0;
            ListaCarrito.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            ListaCarrito.Location = new Point(650, 220);
            ListaCarrito.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            ListaCarrito.Name = "ListaCarrito";
            ListaCarrito.SelectedIndex = -1;
            ListaCarrito.SelectedItem = null;
            ListaCarrito.Size = new Size(300, 380);
            ListaCarrito.TabIndex = 6;
            // 
            // BtnQuitar
            // 
            BtnQuitar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnQuitar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnQuitar.Depth = 0;
            BtnQuitar.HighEmphasis = true;
            BtnQuitar.Icon = null;
            BtnQuitar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            BtnQuitar.Location = new Point(480, 340);
            BtnQuitar.Margin = new Padding(4, 6, 4, 6);
            BtnQuitar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            BtnQuitar.Name = "BtnQuitar";
            BtnQuitar.NoAccentTextColor = Color.Empty;
            BtnQuitar.Size = new Size(73, 36);
            BtnQuitar.TabIndex = 7;
            BtnQuitar.Text = "Quitar";
            BtnQuitar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnQuitar.UseAccentColor = false;
            BtnQuitar.Click += BtnQuitar_Click;
            // 
            // LblTotal
            // 
            LblTotal.Depth = 0;
            LblTotal.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblTotal.ForeColor = Color.FromArgb(0, 255, 135);
            LblTotal.Location = new Point(650, 620);
            LblTotal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            LblTotal.Name = "LblTotal";
            LblTotal.Size = new Size(137, 34);
            LblTotal.TabIndex = 8;
            LblTotal.Text = "Total: ₡0";
            // 
            // BtnGenerarFactura
            // 
            BtnGenerarFactura.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnGenerarFactura.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnGenerarFactura.Depth = 0;
            BtnGenerarFactura.HighEmphasis = true;
            BtnGenerarFactura.Icon = null;
            BtnGenerarFactura.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            BtnGenerarFactura.Location = new Point(650, 660);
            BtnGenerarFactura.Margin = new Padding(4, 6, 4, 6);
            BtnGenerarFactura.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            BtnGenerarFactura.Name = "BtnGenerarFactura";
            BtnGenerarFactura.NoAccentTextColor = Color.Empty;
            BtnGenerarFactura.Size = new Size(155, 36);
            BtnGenerarFactura.TabIndex = 9;
            BtnGenerarFactura.Text = "Generar Factura";
            BtnGenerarFactura.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnGenerarFactura.UseAccentColor = false;
            BtnGenerarFactura.Click += BtnGenerarFactura_Click;
            // 
            // FrmCarrito
            // 
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(980, 720);
            Controls.Add(LblNombreCliente);
            Controls.Add(LblFeria);
            Controls.Add(ComboFerias);
            Controls.Add(ListaProductos);
            Controls.Add(TxtCantidad);
            Controls.Add(BtnAgregar);
            Controls.Add(ListaCarrito);
            Controls.Add(BtnQuitar);
            Controls.Add(LblTotal);
            Controls.Add(BtnGenerarFactura);
            Name = "FrmCarrito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carrito de Compras";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}


