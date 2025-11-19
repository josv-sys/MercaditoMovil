using MercaditoMovil.Application.Services;
using MercaditoMovil.Application.Services.Interfaces;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Views.WinForms.Controllers
{
    /// <summary>
    /// Controller used by the login view to authenticate users.
    /// </summary>
    public class LoginController
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Creates a new login controller using the default authentication service.
        /// </summary>
        public LoginController()
            : this(new AuthService())
        {
        }

        /// <summary>
        /// Creates a new login controller with an injected authentication service.
        /// </summary>
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Tries to authenticate a user with the given credentials.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <param name="password">User password.</param>
        /// <returns>Authenticated user or null when credentials are invalid.</returns>
        public User? SignIn(string email, string password)
        {
            return _authService.SignIn(email, password);
        }
    }
}

