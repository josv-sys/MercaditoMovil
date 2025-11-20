using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MercaditoMovil.Views.WinForms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnOpenRegistration;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            TxtEmail = new System.Windows.Forms.TextBox();
            TxtPassword = new System.Windows.Forms.TextBox();
            BtnLogin = new System.Windows.Forms.Button();
            BtnOpenRegistration = new System.Windows.Forms.Button();

            SuspendLayout();

            // TxtEmail
            TxtEmail.Location = new System.Drawing.Point(30, 30);
            TxtEmail.Size = new System.Drawing.Size(200, 23);

            // TxtPassword
            TxtPassword.Location = new System.Drawing.Point(30, 70);
            TxtPassword.Size = new System.Drawing.Size(200, 23);
            TxtPassword.UseSystemPasswordChar = true;

            // BtnLogin
            BtnLogin.Text = "Iniciar sesion";
            BtnLogin.Location = new System.Drawing.Point(30, 110);
            BtnLogin.Click += BtnLogin_Click;

            // BtnOpenRegistration
            BtnOpenRegistration.Text = "Crear cuenta";
            BtnOpenRegistration.Location = new System.Drawing.Point(30, 150);
            BtnOpenRegistration.Click += BtnOpenRegistration_Click;

            // LoginForm
            Controls.Add(TxtEmail);
            Controls.Add(TxtPassword);
            Controls.Add(BtnLogin);
            Controls.Add(BtnOpenRegistration);

            Text = "Inicio de sesion";
            ClientSize = new System.Drawing.Size(280, 210);

            ResumeLayout(false);
        }
    }
}
