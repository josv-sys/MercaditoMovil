using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MercaditoMovil.Views.WinForms.Controllers;
using MercaditoMovil.Views.WinForms.Models;

namespace MercaditoMovil.Views.WinForms
{
    /// <summary>
    /// Form that allows a new user to register.
    /// </summary>
    public partial class RegistrationForm : Form
    {
        private readonly RegistrationController _controller;
        private readonly LoginForm _loginForm;

        /// <summary>
        /// Creates a new registration form.
        /// </summary>
        /// <param name="loginForm">Reference to the login form to return to.</param>
        public RegistrationForm(LoginForm loginForm)
        {
            InitializeComponent();
            _controller = new RegistrationController();
            _loginForm = loginForm;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            LoadProvinces();
        }

        private void LoadProvinces()
        {
            var provinces = _controller.GetProvinces();

            CmbProvince.Items.Clear();
            int i = 0;
            while (i < provinces.Count)
            {
                CmbProvince.Items.Add(provinces[i]);
                i++;
            }

            CmbProvince.SelectedIndex = provinces.Count > 0 ? 0 : -1;
        }

        private void LoadCantons()
        {
            string province = CmbProvince.SelectedItem as string ?? string.Empty;
            var cantons = _controller.GetCantons(province);

            CmbCanton.Items.Clear();
            int i = 0;
            while (i < cantons.Count)
            {
                CmbCanton.Items.Add(cantons[i]);
                i++;
            }

            CmbCanton.SelectedIndex = cantons.Count > 0 ? 0 : -1;
        }

        private void LoadDistricts()
        {
            string province = CmbProvince.SelectedItem as string ?? string.Empty;
            string canton = CmbCanton.SelectedItem as string ?? string.Empty;

            var districts = _controller.GetDistricts(province, canton);

            CmbDistrict.Items.Clear();
            int i = 0;
            while (i < districts.Count)
            {
                CmbDistrict.Items.Add(districts[i]);
                i++;
            }

            CmbDistrict.SelectedIndex = districts.Count > 0 ? 0 : -1;
        }

        private void CmbProvince_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadCantons();
            LoadDistricts();
        }

        private void CmbCanton_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadDistricts();
        }

        private void BtnRegister_Click(object? sender, EventArgs e)
        {
            var model = new RegistrationViewModel
            {
                FirstName = TxtFirstName.Text,
                LastName1 = TxtLastName1.Text,
                LastName2 = TxtLastName2.Text,
                NationalId = TxtNationalId.Text,
                Email = TxtEmail.Text,
                Phone = TxtPhone.Text,
                Username = TxtUsername.Text,
                Password = TxtPassword.Text,
                Province = CmbProvince.SelectedItem as string ?? string.Empty,
                Canton = CmbCanton.SelectedItem as string ?? string.Empty,
                District = CmbDistrict.SelectedItem as string ?? string.Empty,
                Address = TxtAddress.Text
            };

            List<string> messages;
            bool success = _controller.Register(model, out messages);

            if (!success)
            {
                // Registration failed: show errors.
                var builder = new StringBuilder();
                int i = 0;
                while (i < messages.Count)
                {
                    builder.AppendLine(messages[i]);
                    i++;
                }

                MessageBox.Show(builder.ToString(), "Error en registro");
                return;
            }

            // Registration succeeded: show success and possible warnings.
            if (messages.Count == 0)
            {
                MessageBox.Show("Registro completado correctamente.", "Registro");
            }
            else
            {
                var builder = new StringBuilder();
                builder.AppendLine("Registro completado correctamente.");
                builder.AppendLine();

                int i = 0;
                while (i < messages.Count)
                {
                    builder.AppendLine(messages[i]);
                    i++;
                }

                MessageBox.Show(builder.ToString(), "Registro");
            }

            // Return to login after successful registration.
            _loginForm.Show();
            Close();
        }

        private void BtnBackToLogin_Click(object? sender, EventArgs e)
        {
            _loginForm.Show();
            Close();
        }
    }
}
