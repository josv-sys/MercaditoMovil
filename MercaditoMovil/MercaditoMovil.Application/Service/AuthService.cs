using MercaditoMovil.Application.Validators;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Entities.User;
using MercaditoMovil.Domain.Interfaces.IUserRepository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercaditoMovil.Application.Service
{
    /// <summary>
    /// Provides login and registration using a repository and validators
    /// </summary>
    public class AuthService
    {
        private readonly IUserRepository _users;

        /// <summary>
        /// Creates the service with a user repository.
        /// </summary>
        public AuthService(IUserRepository users) => _users = users;

        /// <summary>
        /// Returns the user when credentials are valid; otherwise null.
        /// </summary>
        public User? Login(string username, string password)
        {
            var errs = UserValidator.ValidateCredentials(username, password);
            if (errs.Count > 0) return null;

            username = username.Trim();
            var u = _users.FindByUsername(username);
            if (u == null) return null;
            return u.Password == password.Trim() ? u : null;
        }

        /// <summary>
        /// Registers a new user after validation and uniqueness checks.
        /// Returns the created user or null on failure.
        /// </summary>
        public User? RegisterBasic(
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
            out List<string>? errors)
        {
            var errs = UserValidator.ValidateRegistration(username, password, nationalId, email, phone);
            if (errs.Count > 0)
            {
                errors = null;
                return null;
            }

            username = username.Trim();
            if (_users.UsernameExists(username))
            {
                errors = null;
                return null;
            }

            nationalId = NormalizeNationalId(nationalId);
            if (nationalId.Length > 0 && _users.NationalIdExists(nationalId))
            {
                errors = null;
                return null;
            }

            string newId = "USR-" + Guid.NewGuid().ToString("N")[..8].ToUpper();

            firstName ??= ""; lastName1 ??= ""; lastName2 ??= "";
            email ??= ""; phone ??= "";
            province ??= ""; canton ??= ""; district ??= "";
            exactAddress ??= ""; marketId ??= "";

            var user = new User(
                newId, username, password ?? "",
                firstName, lastName1, lastName2,
                nationalId, email, phone,
                province, canton, district, exactAddress, marketId);
            errors = null;
            return _users.Add(user);
        }

        private string NormalizeNationalId(string nationalId)
        {
            throw new NotImplementedException();
        }
    }
}

