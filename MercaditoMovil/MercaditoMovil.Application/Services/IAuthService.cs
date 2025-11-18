using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Application.Services
{
    /// <summary>
    /// Define operaciones de autenticacion de usuarios.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Intenta autenticar un usuario a partir de su correo y contrasena.
        /// </summary>
        /// <param name="email">Correo del usuario.</param>
        /// <param name="password">Contrasena del usuario.</param>
        /// <returns>
        /// Usuario autenticado cuando las credenciales son validas;
        /// en caso contrario devuelve null.
        /// </returns>
        User? IniciarSesion(string email, string password);
    }
}
