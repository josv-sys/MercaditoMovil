namespace MercaditoMovil.Views.WinForms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            TxtEmail = new System.Windows.Forms.TextBox();
            TxtPassword = new System.Windows.Forms.TextBox();
            BtnLogin = new System.Windows.Forms.Button();

            SuspendLayout();

            TxtEmail.Location = new System.Drawing.Point(30, 30);
            TxtEmail.Size = new System.Drawing.Size(200, 23);

            TxtPassword.Location = new System.Drawing.Point(30, 70);
            TxtPassword.Size = new System.Drawing.Size(200, 23);

            BtnLogin.Text = "Login";
            BtnLogin.Location = new System.Drawing.Point(30, 110);
            BtnLogin.Click += BtnLogin_Click;

            Controls.Add(TxtEmail);
            Controls.Add(TxtPassword);
            Controls.Add(BtnLogin);

            Text = "Login";
            ClientSize = new System.Drawing.Size(280, 180);

            ResumeLayout(false);
        }
    }
}


