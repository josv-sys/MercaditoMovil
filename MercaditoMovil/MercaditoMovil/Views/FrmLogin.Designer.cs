namespace MercaditoMovil.Views.WinForms
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        private ReaLTaiizor.Controls.MaterialTextBoxEdit TxtCorreo;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit TxtContrasena;
        private ReaLTaiizor.Controls.MaterialButton BtnIngresar;
        private System.Windows.Forms.Label LblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            TxtCorreo = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            TxtContrasena = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            BtnIngresar = new ReaLTaiizor.Controls.MaterialButton();
            LblTitulo = new Label();
            SuspendLayout();
            // 
            // TxtCorreo
            // 
            TxtCorreo.AnimateReadOnly = false;
            TxtCorreo.AutoCompleteMode = AutoCompleteMode.None;
            TxtCorreo.AutoCompleteSource = AutoCompleteSource.None;
            TxtCorreo.BackColor = Color.FromArgb(35, 35, 35);
            TxtCorreo.BackgroundImageLayout = ImageLayout.None;
            TxtCorreo.CharacterCasing = CharacterCasing.Normal;
            TxtCorreo.Depth = 0;
            TxtCorreo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtCorreo.HideSelection = true;
            TxtCorreo.Hint = "Correo electrónico";
            TxtCorreo.LeadingIcon = null;
            TxtCorreo.Location = new Point(60, 136);
            TxtCorreo.MaxLength = 32767;
            TxtCorreo.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            TxtCorreo.Name = "TxtCorreo";
            TxtCorreo.PasswordChar = '\0';
            TxtCorreo.PrefixSuffixText = null;
            TxtCorreo.ReadOnly = false;
            TxtCorreo.RightToLeft = RightToLeft.No;
            TxtCorreo.SelectedText = "";
            TxtCorreo.SelectionLength = 0;
            TxtCorreo.SelectionStart = 0;
            TxtCorreo.ShortcutsEnabled = true;
            TxtCorreo.Size = new Size(300, 48);
            TxtCorreo.TabIndex = 1;
            TxtCorreo.TabStop = false;
            TxtCorreo.TextAlign = HorizontalAlignment.Left;
            TxtCorreo.TrailingIcon = null;
            TxtCorreo.UseSystemPasswordChar = false;
            // 
            // TxtContrasena
            // 
            TxtContrasena.AnimateReadOnly = false;
            TxtContrasena.AutoCompleteMode = AutoCompleteMode.None;
            TxtContrasena.AutoCompleteSource = AutoCompleteSource.None;
            TxtContrasena.BackColor = Color.FromArgb(35, 35, 35);
            TxtContrasena.BackgroundImageLayout = ImageLayout.None;
            TxtContrasena.CharacterCasing = CharacterCasing.Normal;
            TxtContrasena.Depth = 0;
            TxtContrasena.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtContrasena.HideSelection = true;
            TxtContrasena.Hint = "Contraseña";
            TxtContrasena.LeadingIcon = null;
            TxtContrasena.Location = new Point(60, 190);
            TxtContrasena.MaxLength = 32767;
            TxtContrasena.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            TxtContrasena.Name = "TxtContrasena";
            TxtContrasena.PasswordChar = '●';
            TxtContrasena.PrefixSuffixText = null;
            TxtContrasena.ReadOnly = false;
            TxtContrasena.RightToLeft = RightToLeft.No;
            TxtContrasena.SelectedText = "";
            TxtContrasena.SelectionLength = 0;
            TxtContrasena.SelectionStart = 0;
            TxtContrasena.ShortcutsEnabled = true;
            TxtContrasena.Size = new Size(300, 48);
            TxtContrasena.TabIndex = 2;
            TxtContrasena.TabStop = false;
            TxtContrasena.TextAlign = HorizontalAlignment.Left;
            TxtContrasena.TrailingIcon = null;
            TxtContrasena.UseSystemPasswordChar = true;
            // 
            // BtnIngresar
            // 
            BtnIngresar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnIngresar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnIngresar.Depth = 0;
            BtnIngresar.HighEmphasis = true;
            BtnIngresar.Icon = null;
            BtnIngresar.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            BtnIngresar.Location = new Point(143, 247);
            BtnIngresar.Margin = new Padding(4, 6, 4, 6);
            BtnIngresar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.NoAccentTextColor = Color.Empty;
            BtnIngresar.Size = new Size(91, 36);
            BtnIngresar.TabIndex = 3;
            BtnIngresar.Text = "Ingresar";
            BtnIngresar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnIngresar.UseAccentColor = false;
            BtnIngresar.Click += BtnIngresar_Click;
            // 
            // LblTitulo
            // 
            LblTitulo.AutoSize = true;
            LblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            LblTitulo.ForeColor = Color.White;
            LblTitulo.Location = new Point(91, 64);
            LblTitulo.Name = "LblTitulo";
            LblTitulo.Size = new Size(231, 37);
            LblTitulo.TabIndex = 0;
            LblTitulo.Text = "Mercadito Móvil";
            LblTitulo.Click += LblTitulo_Click;
            // 
            // FrmLogin
            // 
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(420, 420);
            Controls.Add(LblTitulo);
            Controls.Add(TxtCorreo);
            Controls.Add(TxtContrasena);
            Controls.Add(BtnIngresar);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de sesión";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}



