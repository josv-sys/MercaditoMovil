using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MercaditoMovil.Application.Validators
{
    /// <summary>
    /// Basic validation rules for user data.
    /// </summary>
    public static partial class UserValidator
    {
        /// <summary>
        /// Validates login credentials.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">User password.</param>
        /// <returns>List of validation error messages.</returns>
        public static List<string> ValidateCredentials(string username, string password)
        {
            var errors = new List<string>();

            username ??= string.Empty;
            password ??= string.Empty;

            username = username.Trim();
            password = password.Trim();

            if (username.Length == 0)
            {
                errors.Add("El usuario es obligatorio.");
            }

            if (password.Length == 0)
            {
                errors.Add("La contrasena es obligatoria.");
            }

            return errors;
        }

        /// <summary>
        /// Validates minimal fields required to register a user.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">User password.</param>
        /// <param name="nationalId">National ID.</param>
        /// <param name="email">Email address.</param>
        /// <param name="phone">Phone number.</param>
        /// <returns>List of validation error messages.</returns>
        public static List<string> ValidateRegistration(
            string username,
            string password,
            string nationalId,
            string email,
            string phone)
        {
            var errors = ValidateCredentials(username, password);

            nationalId ??= string.Empty;
            email ??= string.Empty;
            phone ??= string.Empty;

            nationalId = nationalId.Trim();
            email = email.Trim();
            phone = phone.Trim();

            if (nationalId.Length > 0 && !CedulaRegex().IsMatch(nationalId))
            {
                errors.Add("La cedula debe tener 9 digitos.");
            }

            if (email.Length > 0 && !email.Contains("@"))
            {
                errors.Add("El correo no es valido.");
            }

            if (phone.Length > 0 && !Regex.IsMatch(phone, @"^\d{8}$"))
            {
                errors.Add("El telefono debe tener 8 digitos.");
            }

            return errors;
        }

        [GeneratedRegex(@"^\d{9}$")]
        private static partial Regex CedulaRegex();
    }
}
