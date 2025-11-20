using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MercaditoMovil.Views.WinForms
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label LblFirstName;
        private System.Windows.Forms.Label LblLastName1;
        private System.Windows.Forms.Label LblLastName2;
        private System.Windows.Forms.Label LblNationalId;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblPhone;
        private System.Windows.Forms.Label LblPhoneExample;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblProvince;
        private System.Windows.Forms.Label LblCanton;
        private System.Windows.Forms.Label LblDistrict;
        private System.Windows.Forms.Label LblAddress;

        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.TextBox TxtLastName1;
        private System.Windows.Forms.TextBox TxtLastName2;
        private System.Windows.Forms.TextBox TxtNationalId;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtPhone;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.ComboBox CmbProvince;
        private System.Windows.Forms.ComboBox CmbCanton;
        private System.Windows.Forms.ComboBox CmbDistrict;
        private System.Windows.Forms.TextBox TxtAddress;

        private System.Windows.Forms.Button BtnRegister;
        private System.Windows.Forms.Button BtnBackToLogin;

        /// <summary>
        /// Disposes resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes UI components.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            LblFirstName = new System.Windows.Forms.Label();
            LblLastName1 = new System.Windows.Forms.Label();
            LblLastName2 = new System.Windows.Forms.Label();
            LblNationalId = new System.Windows.Forms.Label();
            LblEmail = new System.Windows.Forms.Label();
            LblPhone = new System.Windows.Forms.Label();
            LblPhoneExample = new System.Windows.Forms.Label();
            LblUsername = new System.Windows.Forms.Label();
            LblPassword = new System.Windows.Forms.Label();
            LblProvince = new System.Windows.Forms.Label();
            LblCanton = new System.Windows.Forms.Label();
            LblDistrict = new System.Windows.Forms.Label();
            LblAddress = new System.Windows.Forms.Label();

            TxtFirstName = new System.Windows.Forms.TextBox();
            TxtLastName1 = new System.Windows.Forms.TextBox();
            TxtLastName2 = new System.Windows.Forms.TextBox();
            TxtNationalId = new System.Windows.Forms.TextBox();
            TxtEmail = new System.Windows.Forms.TextBox();
            TxtPhone = new System.Windows.Forms.TextBox();
            TxtUsername = new System.Windows.Forms.TextBox();
            TxtPassword = new System.Windows.Forms.TextBox();
            CmbProvince = new System.Windows.Forms.ComboBox();
            CmbCanton = new System.Windows.Forms.ComboBox();
            CmbDistrict = new System.Windows.Forms.ComboBox();
            TxtAddress = new System.Windows.Forms.TextBox();

            BtnRegister = new System.Windows.Forms.Button();
            BtnBackToLogin = new System.Windows.Forms.Button();

            SuspendLayout();

            // Labels
            LblFirstName.Text = "Nombre";
            LblFirstName.Location = new System.Drawing.Point(20, 20);
            LblFirstName.AutoSize = true;

            LblLastName1.Text = "Primer apellido";
            LblLastName1.Location = new System.Drawing.Point(20, 70);
            LblLastName1.AutoSize = true;

            LblLastName2.Text = "Segundo apellido";
            LblLastName2.Location = new System.Drawing.Point(20, 120);
            LblLastName2.AutoSize = true;

            LblNationalId.Text = "Cedula (sin guiones)";
            LblNationalId.Location = new System.Drawing.Point(20, 170);
            LblNationalId.AutoSize = true;

            LblEmail.Text = "Correo";
            LblEmail.Location = new System.Drawing.Point(20, 220);
            LblEmail.AutoSize = true;

            LblPhone.Text = "Telefono";
            LblPhone.Location = new System.Drawing.Point(20, 270);
            LblPhone.AutoSize = true;

            LblPhoneExample.Text = "Ejemplo: 88888888";
            LblPhoneExample.Location = new System.Drawing.Point(110, 290);
            LblPhoneExample.AutoSize = true;

            LblUsername.Text = "Nombre de usuario";
            LblUsername.Location = new System.Drawing.Point(20, 320);
            LblUsername.AutoSize = true;

            LblPassword.Text = "Contrasena";
            LblPassword.Location = new System.Drawing.Point(20, 370);
            LblPassword.AutoSize = true;

            LblProvince.Text = "Provincia";
            LblProvince.Location = new System.Drawing.Point(320, 20);
            LblProvince.AutoSize = true;

            LblCanton.Text = "Canton";
            LblCanton.Location = new System.Drawing.Point(320, 70);
            LblCanton.AutoSize = true;

            LblDistrict.Text = "Distrito";
            LblDistrict.Location = new System.Drawing.Point(320, 120);
            LblDistrict.AutoSize = true;

            LblAddress.Text = "Direccion exacta";
            LblAddress.Location = new System.Drawing.Point(320, 170);
            LblAddress.AutoSize = true;

            // TextBoxes
            TxtFirstName.Location = new System.Drawing.Point(20, 40);
            TxtFirstName.Size = new System.Drawing.Size(250, 23);

            TxtLastName1.Location = new System.Drawing.Point(20, 90);
            TxtLastName1.Size = new System.Drawing.Size(250, 23);

            TxtLastName2.Location = new System.Drawing.Point(20, 140);
            TxtLastName2.Size = new System.Drawing.Size(250, 23);

            TxtNationalId.Location = new System.Drawing.Point(20, 190);
            TxtNationalId.Size = new System.Drawing.Size(250, 23);

            TxtEmail.Location = new System.Drawing.Point(20, 240);
            TxtEmail.Size = new System.Drawing.Size(250, 23);

            TxtPhone.Location = new System.Drawing.Point(20, 290);
            TxtPhone.Size = new System.Drawing.Size(80, 23);

            TxtUsername.Location = new System.Drawing.Point(20, 340);
            TxtUsername.Size = new System.Drawing.Size(250, 23);

            TxtPassword.Location = new System.Drawing.Point(20, 390);
            TxtPassword.Size = new System.Drawing.Size(250, 23);
            TxtPassword.UseSystemPasswordChar = true;

            // ComboBoxes
            CmbProvince.Location = new System.Drawing.Point(320, 40);
            CmbProvince.Size = new System.Drawing.Size(200, 23);
            CmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbProvince.SelectedIndexChanged += CmbProvince_SelectedIndexChanged;

            CmbCanton.Location = new System.Drawing.Point(320, 90);
            CmbCanton.Size = new System.Drawing.Size(200, 23);
            CmbCanton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbCanton.SelectedIndexChanged += CmbCanton_SelectedIndexChanged;

            CmbDistrict.Location = new System.Drawing.Point(320, 140);
            CmbDistrict.Size = new System.Drawing.Size(200, 23);
            CmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            TxtAddress.Location = new System.Drawing.Point(320, 190);
            TxtAddress.Size = new System.Drawing.Size(300, 80);
            TxtAddress.Multiline = true;

            // Buttons
            BtnRegister.Text = "Registrarme";
            BtnRegister.Location = new System.Drawing.Point(320, 300);
            BtnRegister.Size = new System.Drawing.Size(120, 30);
            BtnRegister.Click += BtnRegister_Click;

            BtnBackToLogin.Text = "Volver al login";
            BtnBackToLogin.Location = new System.Drawing.Point(460, 300);
            BtnBackToLogin.Size = new System.Drawing.Size(120, 30);
            BtnBackToLogin.Click += BtnBackToLogin_Click;

            // RegistrationForm
            ClientSize = new System.Drawing.Size(650, 450);
            Controls.Add(LblFirstName);
            Controls.Add(LblLastName1);
            Controls.Add(LblLastName2);
            Controls.Add(LblNationalId);
            Controls.Add(LblEmail);
            Controls.Add(LblPhone);
            Controls.Add(LblPhoneExample);
            Controls.Add(LblUsername);
            Controls.Add(LblPassword);
            Controls.Add(LblProvince);
            Controls.Add(LblCanton);
            Controls.Add(LblDistrict);
            Controls.Add(LblAddress);

            Controls.Add(TxtFirstName);
            Controls.Add(TxtLastName1);
            Controls.Add(TxtLastName2);
            Controls.Add(TxtNationalId);
            Controls.Add(TxtEmail);
            Controls.Add(TxtPhone);
            Controls.Add(TxtUsername);
            Controls.Add(TxtPassword);
            Controls.Add(CmbProvince);
            Controls.Add(CmbCanton);
            Controls.Add(CmbDistrict);
            Controls.Add(TxtAddress);

            Controls.Add(BtnRegister);
            Controls.Add(BtnBackToLogin);

            Text = "Registro de usuario";
            Load += RegistrationForm_Load;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
