using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Define las operaciones basicas para trabajar con usuarios.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Devuelve la lista completa de usuarios.
        /// </summary>
        List<User> GetAll();

        /// <summary>
        /// Devuelve un usuario por su nombre de usuario o null cuando no existe.
        /// </summary>
        User? GetByUsername(string username);

        /// <summary>
        /// Indica si el nombre de usuario ya existe.
        /// </summary>
        bool UsernameExists(string username);

        /// <summary>
        /// Indica si la cedula ya existe.
        /// </summary>
        bool NationalIdExists(string nationalId);

        /// <summary>
        /// Agrega un nuevo usuario al origen de datos.
        /// </summary>
        User Add(User user);
    }
}
