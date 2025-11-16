using System;
using System.Windows.Forms;
using ReaLTaiizor.Forms;
using MercaditoMovil.Application.Services;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Views.WinForms
{
    public partial class FrmLogin : MaterialForm
    {
        private readonly AuthService _auth;

        public FrmLogin()
        {
            InitializeComponent();
            _auth = new AuthService();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string correo = TxtCorreo.Text.Trim();
            string pass = TxtContrasena.Text.Trim();

            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            Usuario? usuario = _auth.IniciarSesion(correo, pass);

            if (usuario == null)
            {
                MessageBox.Show("Correo o contraseña incorrectos.");
                return;
            }

            MessageBox.Show(
             $"UserId: {usuario.UserId}\n" +
             $"Nombre: {usuario.Nombre}\n" +
             $"Correo: {usuario.Correo}\n" +
            $"MarketId: {usuario.MarketId}",
            "DEBUG LOGIN");


            FrmCarrito frm = new FrmCarrito(usuario);
            frm.Show();
            this.Hide();
        }

        private void LblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
