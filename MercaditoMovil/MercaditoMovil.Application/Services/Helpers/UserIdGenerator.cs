using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Application.Services.Helpers
{
    /// <summary>
    /// Generates unique identifiers for users.
    /// </summary>
    public static class UserIdGenerator
    {
        /// <summary>
        /// Generates a new user identifier that does not exist in the given list.
        /// </summary>
        /// <param name="existingUsers">List of existing users.</param>
        /// <returns>Unique user identifier.</returns>
        public static string GenerateUserId(List<User> existingUsers)
        {
            var random = new Random();
            const string prefix = "USR-";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            while (true)
            {
                var builder = new StringBuilder();
                builder.Append(prefix);

                int i = 0;
                while (i < 8)
                {
                    int index = random.Next(0, chars.Length);
                    builder.Append(chars[index]);
                    i++;
                }

                string candidate = builder.ToString();

                bool exists = false;
                int j = 0;
                while (j < existingUsers.Count)
                {
                    if (string.Equals(existingUsers[j].UserId, candidate, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }

                    j++;
                }

                if (!exists)
                {
                    return candidate;
                }
            }
        }
    }
}
