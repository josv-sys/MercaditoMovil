using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repository abstraction for working with users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Returns all users.
        /// </summary>
        List<User> GetAll();

        /// <summary>
        /// Returns a user by username or null when it does not exist.
        /// </summary>
        User? GetByUsername(string username);

        /// <summary>
        /// Indicates whether a username already exists.
        /// </summary>
        bool UsernameExists(string username);

        /// <summary>
        /// Indicates whether a national ID already exists.
        /// </summary>
        bool NationalIdExists(string nationalId);

        /// <summary>
        /// Adds a new user to the data source.
        /// </summary>
        User Add(User user);
    }
}
