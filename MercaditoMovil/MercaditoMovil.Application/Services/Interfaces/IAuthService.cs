using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Application.Services.Interfaces
{
    /// <summary>
    /// Defines operations for user authentication.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Tries to authenticate a user using the given email and password.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <param name="password">User password.</param>
        /// <returns>Authenticated user when credentials are valid; otherwise null.</returns>
        User? SignIn(string email, string password);
    }
}