using System;
using System.Windows.Forms;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Views.WinForms.Controllers;

namespace MercaditoMovil.Views.WinForms
{
    /// <summary>
    /// Login form used to authenticate the user.
    /// </summary>
    public partial class LoginForm : Form
    {
        private readonly LoginController _controller = new LoginController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text.Trim();
            string password = TxtPassword.Text.Trim();

            User? user = _controller.SignIn(email, password);

            if (user == null)
            {
                MessageBox.Show("Correo o contrasena incorrectos.");
                return;
            }

            CartForm form = new CartForm(user);
            form.Show();
            Hide();
        }

        private void BtnOpenRegistration_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm(this);
            registrationForm.Show();
            Hide();
        }
    }
}

