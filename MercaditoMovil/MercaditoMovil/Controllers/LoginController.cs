using MercaditoMovil.Application.Service;
using MercaditoMovil.Domain.Entities.User; // <-- Change this to import the 'User' type directly
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercaditoMovil.Views.Winforms.Controllers
{
    /// <summary>
    /// bridge between forms and AuthService.
    /// </summary>
    public class LoginController
    {
        private readonly AuthService _auth;

        public LoginController(AuthService auth)
        {
            _auth = auth;
        }

        public User Login(string username, string password, out List<string> errors)
        {
            errors = new List<string>();
            var user = _auth.Login(username, password);
            // aqui podriamos agregar mensajes de error mas detallados si se quiere luego pero por ahora dejamos asi
            return user;
        }

        public User RegisterBasic(
            string username,
            string password,
            string firstName,
            string lastName1,
            string lastName2,
            string nationalId,
            string email,
            string phone,
            string province,
            string canton,
            string district,
            string exactAddress,
            string marketId,
            out List<string> errors)
        {
            return _auth.RegisterBasic(
                username, password, firstName, lastName1, lastName2,
                nationalId, email, phone, province, canton, district,
                exactAddress, marketId, out errors);
        }
    }
}

