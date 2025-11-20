using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MercaditoMovil.Application.Validators
{
    /// <summary>
    /// Validates registration data for a new user.
    /// </summary>
    public static class UserRegistrationValidator
    {
        /// <summary>
        /// Validates the user registration information without checking duplicates.
        /// </summary>
        /// <returns>List of validation error messages.</returns>
        public static List<string> ValidateBasicData(
            string firstName,
            string lastName1,
            string lastName2,
            string nationalId,
            string email,
            string phone,
            string username,
            string password,
            string province,
            string canton,
            string district,
            string address)
        {
            var errors = new List<string>();

            firstName ??= string.Empty;
            lastName1 ??= string.Empty;
            lastName2 ??= string.Empty;
            nationalId ??= string.Empty;
            email ??= string.Empty;
            phone ??= string.Empty;
            username ??= string.Empty;
            password ??= string.Empty;
            province ??= string.Empty;
            canton ??= string.Empty;
            district ??= string.Empty;
            address ??= string.Empty;

            firstName = firstName.Trim();
            lastName1 = lastName1.Trim();
            lastName2 = lastName2.Trim();
            nationalId = nationalId.Trim();
            email = email.Trim();
            phone = phone.Trim();
            username = username.Trim();
            password = password.Trim();
            province = province.Trim();
            canton = canton.Trim();
            district = district.Trim();
            address = address.Trim();

            if (firstName.Length == 0)
            {
                errors.Add("El nombre es obligatorio.");
            }

            if (lastName1.Length == 0)
            {
                errors.Add("El primer apellido es obligatorio.");
            }

            if (nationalId.Length == 0)
            {
                errors.Add("La cedula es obligatoria.");
            }
            else if (!Regex.IsMatch(nationalId, @"^\d{9}$"))
            {
                errors.Add("La cedula debe tener 9 digitos sin guiones.");
            }

            if (email.Length == 0)
            {
                errors.Add("El correo es obligatorio.");
            }
            else if (!IsSimpleEmail(email))
            {
                errors.Add("El correo no es valido.");
            }

            if (phone.Length == 0)
            {
                errors.Add("El telefono es obligatorio.");
            }
            else if (!Regex.IsMatch(phone, @"^\d{8}$"))
            {
                errors.Add("El telefono debe tener 8 digitos sin guiones.");
            }

            if (username.Length == 0)
            {
                errors.Add("El nombre de usuario es obligatorio.");
            }
            else if (username.Length < 4 || username.Length > 20)
            {
                errors.Add("El nombre de usuario debe tener entre 4 y 20 caracteres.");
            }

            if (password.Length < 6)
            {
                errors.Add("La contrasena debe tener al menos 6 caracteres.");
            }

            if (province.Length == 0)
            {
                errors.Add("La provincia es obligatoria.");
            }

            if (canton.Length == 0)
            {
                errors.Add("El canton es obligatorio.");
            }

            if (district.Length == 0)
            {
                errors.Add("El distrito es obligatorio.");
            }

            if (address.Length < 10)
            {
                errors.Add("La direccion debe tener al menos 10 caracteres.");
            }

            return errors;
        }

        /// <summary>
        /// Simple email validation used for registration.
        /// </summary>
        private static bool IsSimpleEmail(string email)
        {
            int atIndex = email.IndexOf('@');
            if (atIndex <= 0)
            {
                return false;
            }

            int dotIndex = email.LastIndexOf('.');
            if (dotIndex < atIndex + 2)
            {
                return false;
            }

            if (dotIndex == email.Length - 1)
            {
                return false;
            }

            return true;
        }
    }
}
