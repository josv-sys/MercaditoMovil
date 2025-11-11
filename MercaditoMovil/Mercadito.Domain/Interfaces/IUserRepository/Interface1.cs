using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercaditoMovil.Domain.Interfaces.IUserRepository
{
    /// <summary>
    /// Contract for user persistence operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>Returns all users.</summary>
        List<User> LoadAll();

        /// <summary>Finds a user by username or null.</summary>
        User FindByUsername(string username);

        /// <summary>Returns true if username exists.</summary>
        bool UsernameExists(string username);

        /// <summary>Returns true if national id exists.</summary>
        bool NationalIdExists(string nationalId);

        /// <summary>Persists a new user and returns it.</summary>
        User Add(User user);
    }
}
