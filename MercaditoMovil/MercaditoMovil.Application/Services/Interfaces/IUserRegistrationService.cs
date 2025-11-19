using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Application.Services
{
    /// <summary>
    /// Defines operations for user registration.
    /// </summary>
    public interface IUserRegistrationService
    {
        /// <summary>
        /// Registers a new user using the provided data.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName1">First last name.</param>
        /// <param name="lastName2">Second last name.</param>
        /// <param name="nationalId">National ID (cedula).</param>
        /// <param name="email">Email address.</param>
        /// <param name="phone">Phone number.</param>
        /// <param name="username">Desired username (can be empty to auto-generate).</param>
        /// <param name="password">Password.</param>
        /// <param name="province">Province name.</param>
        /// <param name="canton">Canton name.</param>
        /// <param name="district">District name.</param>
        /// <param name="address">Exact address.</param>
        /// <param name="errors">List that will contain validation error messages.</param>
        /// <returns>Registered user when successful; otherwise null.</returns>
        User? RegisterUser(
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
            out List<string> errors);
    }
}
