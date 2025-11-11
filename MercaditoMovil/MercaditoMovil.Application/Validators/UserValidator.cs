using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MercaditoMovil.Application.Validators
{
    /// <summary>
    /// Basic validation rules for user inputs
    /// </summary>
    public static partial class UserValidator
    {
        /// <summary>
        /// Validates login credentials
        /// </summary>
        public static List<string> ValidateCredentials(string username, string password)
        {
            var errors = new List<string>();

            username ??= ""; password ??= "";
            username = username.Trim(); password = password.Trim();

            if (username.Length == 0) errors.Add("El usuario es obligatorio.");
            if (password.Length == 0) errors.Add("La contraseña es obligatoria.");

            return errors;
        }

        /// <summary>
        /// Validates minimal registration fields
        /// </summary>
        public static List<string> ValidateRegistration(
            string username,
            string password,
            string nationalId,
            string email,
            string phone)
        {
            var errors = ValidateCredentials(username, password);

            nationalId ??= ""; email ??= ""; phone ??= "";
            nationalId = nationalId.Trim(); email = email.Trim(); phone = phone.Trim();

            if (nationalId.Length > 0 && !CedulaRegex().IsMatch(nationalId))
                errors.Add("La cédula debe tener 9 dígitos.");
            if (email.Length > 0 && !email.Contains('@'))
                errors.Add("El correo no es válido.");
            if (phone.Length > 0 && !Regex.IsMatch(phone, @"^\d{8}$"))
                errors.Add("El teléfono debe tener 8 dígitos.");

            return errors;
        }

        [GeneratedRegex(@"^\d{9}$")]
        private static partial Regex CedulaRegex();
    }
}
