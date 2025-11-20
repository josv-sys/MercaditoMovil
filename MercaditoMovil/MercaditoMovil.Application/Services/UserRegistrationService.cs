using System;
using System.Collections.Generic;
using MercaditoMovil.Application.Services.Helpers;
using MercaditoMovil.Application.Validators;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Interfaces.Repositories;
using MercaditoMovil.Infrastructure.Repositories;

namespace MercaditoMovil.Application.Services
{
    /// <summary>
    /// Handles the complete process of registering a new user.
    /// </summary>
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly MarketRepository _marketRepository;

        /// <summary>
        /// Creates a new instance using the default CSV repositories.
        /// </summary>
        public UserRegistrationService()
        {
            _userRepository = new CsvUserRepository();
            _marketRepository = new MarketRepository();
        }

        /// <inheritdoc />
        public User? RegisterUser(
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
            string address,
            out List<string> errors)
        {
            // 1. Basic validation (formats and required fields)
            errors = UserRegistrationValidator.ValidateBasicData(
                firstName,
                lastName1,
                lastName2,
                nationalId,
                email,
                phone,
                username,
                password,
                province,
                canton,
                district,
                address);

            if (errors.Count > 0)
            {
                return null;
            }

            // Normalization
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

            // 2. Load existing users
            List<User> existingUsers = _userRepository.GetAll();

            // 3. Auto-generate username if needed
            if (username.Length == 0)
            {
                username = GenerateUsername(firstName, lastName1, existingUsers);
            }
            else if (UsernameExists(existingUsers, username))
            {
                errors.Add("El nombre de usuario ya existe.");
            }

            // 4. Check duplicates for email and nationalId
            if (EmailExists(existingUsers, email))
            {
                errors.Add("El correo ya esta registrado.");
            }

            if (NationalIdExists(existingUsers, nationalId))
            {
                errors.Add("La cedula ya esta registrada.");
            }

            if (errors.Count > 0)
            {
                return null;
            }

            // 5. Generate UserId
            string userId = UserIdGenerator.GenerateUserId(existingUsers);

            // 6. Calculate MarketId
            string marketId = CalculateMarketId(province, canton, district);

            // 7. Create user entity
            var user = new User(
                userId,
                username,
                password,
                firstName,
                lastName1,
                lastName2,
                nationalId,
                email,
                phone,
                province,
                canton,
                district,
                address,
                marketId);

            // 8. Persist user
            _userRepository.Add(user);

            // 9. Warn about out-of-coverage market
            if (marketId == "MKT-000")
            {
                errors.Add("No hay ferias disponibles en su zona. Se le asigno un usuario fuera de cobertura.");
            }

            return user;
        }

        /// <summary>
        /// Generates a username that does not exist in the list.
        /// </summary>
        private static string GenerateUsername(string firstName, string lastName1, List<User> users)
        {
            string baseName = (firstName + "." + lastName1).ToLower();

            // Remove spaces
            baseName = baseName.Replace(" ", string.Empty);

            if (baseName.Length < 4)
            {
                baseName = "user";
            }

            string candidate = baseName;
            int suffix = 1;

            while (UsernameExists(users, candidate))
            {
                candidate = baseName + suffix.ToString();
                suffix++;
            }

            return candidate;
        }

        /// <summary>
        /// Checks if the username already exists among the users.
        /// </summary>
        private static bool UsernameExists(List<User> users, string username)
        {
            int i = 0;
            while (i < users.Count)
            {
                if (string.Equals(users[i].Username, username, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                i++;
            }

            return false;
        }

        /// <summary>
        /// Checks if the email already exists among the users.
        /// </summary>
        private static bool EmailExists(List<User> users, string email)
        {
            int i = 0;
            while (i < users.Count)
            {
                if (string.Equals(users[i].Email, email, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                i++;
            }

            return false;
        }

        /// <summary>
        /// Checks if the national ID already exists among the users.
        /// </summary>
        private static bool NationalIdExists(List<User> users, string nationalId)
        {
            int i = 0;
            while (i < users.Count)
            {
                if (string.Equals(users[i].NationalId, nationalId, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                i++;
            }

            return false;
        }

        /// <summary>
        /// Calculates the market identifier using the user location.
        /// </summary>
        private static string Normalize(string value)
        {
            if (value == null) return string.Empty;

            value = value.Trim().ToLower();

            value = value.Replace("á", "a")
                         .Replace("é", "e")
                         .Replace("í", "i")
                         .Replace("ó", "o")
                         .Replace("ú", "u")
                         .Replace("ü", "u")
                         .Replace("ñ", "n");

            return value;
        }

        private string CalculateMarketId(string province, string canton, string district)
        {
            var markets = _marketRepository.GetAll();

            string nProvince = Normalize(province);
            string nCanton = Normalize(canton);
            string nDistrict = Normalize(district);

            int i = 0;

            // 1. Province + District exact match
            while (i < markets.Count)
            {
                var m = markets[i];

                if (Normalize(m.Province) == nProvince &&
                    Normalize(m.District) == nDistrict)
                {
                    return m.MarketId;
                }

                i++;
            }

            // 2. Province match only
            i = 0;
            while (i < markets.Count)
            {
                var m = markets[i];

                if (Normalize(m.Province) == nProvince)
                {
                    return m.MarketId;
                }

                i++;
            }

            // 3. Out of coverage
            return "MKT-000";
        }
    }
}
