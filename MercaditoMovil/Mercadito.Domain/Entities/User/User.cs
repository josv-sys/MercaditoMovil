using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercaditoMovil.Domain.Entities.User
{
    /// <summary>
    /// Represents a registered user and its persisted fields.
    /// </summary>
    public class User
    {
        public string UserId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName1 { get; private set; }
        public string LastName2 { get; private set; }
        public string NationalId { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Province { get; private set; }
        public string Canton { get; private set; }
        public string District { get; private set; }
        public string ExactAddress { get; private set; }
        public string MarketId { get; private set; }

        /// <summary>
        /// Builds a <c>User</c> normalizing nulls and trimming values.
        /// </summary>
        public User(
            string userId,
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
            string marketId)
        {
            userId ??= "";
            username ??= "";
            password ??= "";
            firstName ??= "";
            lastName1 ??= "";
            lastName2 ??= "";
            nationalId ??= "";
            email ??= "";
            phone ??= "";
            province ??= "";
            canton ??= "";
            district ??= "";
            exactAddress ??= "";
            marketId ??= "";

            UserId = userId.Trim();
            Username = username.Trim();
            Password = password.Trim();
            FirstName = firstName.Trim();
            LastName1 = lastName1.Trim();
            LastName2 = lastName2.Trim();
            NationalId = nationalId.Trim();
            Email = email.Trim();
            Phone = phone.Trim();
            Province = province.Trim();
            Canton = canton.Trim();
            District = district.Trim();
            ExactAddress = exactAddress.Trim();
            MarketId = marketId.Trim();
        }
    }
}
