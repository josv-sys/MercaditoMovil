using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Entities.User;
using MercaditoMovil.Domain.Interfaces.IUserRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// CSV-based implementation of <c>IUserRepository</c>.
    /// Quoted fields are supported for commas inside addresses.
    /// </summary>
    public class CsvUserRepository(string filePath) : IUserRepository
    {
        private readonly string _filePath = filePath;

        /// <inheritdoc/>
        public List<User> LoadAll()
        {
            var list = new List<User>();

            if (!File.Exists(_filePath))
                return list;

            var lines = File.ReadAllLines(_filePath, Encoding.UTF8);
            for (int i = 1; i < lines.Length; i++) // esto lo uso por ahora para quitar la primera linea, preguntar al profe
            {
                var line = lines[i];
                if (line != null && line.Length > 0)
                {
                    var parts = SplitCsv(line);
                    if (parts.Length >= 14)
                    {
                        var u = new User( //esto es para que calze con el constructor, preguntar si se puede hacer mejor
                            parts[0], parts[1], parts[2], parts[3],
                            parts[4], parts[5], parts[6], parts[7],
                            parts[8], parts[9], parts[10], parts[11],
                            parts[12], parts[13]);
                        list.Add(u);
                    }
                }
            }
            return list;
        }

        /// <inheritdoc/>
        public User FindByUsername(string username)
        {
            if (username == null) return null;
            username = username.Trim();
            var all = LoadAll();

            int i = 0;
            while (i < all.Count)
            {
                var u = all[i];
                if (string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase))
                    return u;
                i++;
            }
            return null;
        }

        /// <inheritdoc/>
        public bool UsernameExists(string username)
        {
            return FindByUsername(username) != null;
        }

        /// <inheritdoc/>
        public bool NationalIdExists(string nationalId)
        {
            if (nationalId == null) return false;
            nationalId = nationalId.Trim();
            var all = LoadAll();

            int i = 0;
            while (i < all.Count)
            {
                if (string.Equals(all[i].NationalId, nationalId, StringComparison.OrdinalIgnoreCase))
                    return true;
                i++;
            }
            return false;
        }

        /// <inheritdoc/>
        public User Add(User user)
        {
            // esto asume que el archivo ya existe y tiene la cabecera, luis deberia ver si lo dejamos asi o le agregamos codigo para crear el archivo con la cabecera si no existe
            var cols = new[]
            {
                user.UserId, user.Username, user.Password, user.FirstName,
                user.LastName1, user.LastName2, user.NationalId, user.Email,
                user.Phone, user.Province, user.Canton, user.District,
                user.ExactAddress, user.MarketId
            };

            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] = EscapeCsv(cols[i]);
            }

            string line = string.Join(",", cols);
            File.AppendAllText(_filePath, Environment.NewLine + line, Encoding.UTF8);
            return user;
        }

        /// <summary>
        /// Splits a CSV line honoring quotes for commas inside fields.
        /// </summary>
        private static string[] SplitCsv(string line)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            bool inQuotes = false;
            int i = 0;

            while (i < line.Length)
            {
                char c = line[i];
                if (c == '\"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ',' && !inQuotes) // se supone que esto deberia funcionar bien aun si hay comas dentro de las comillas, preguntar al profe
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
                i++;
            }

            result.Add(sb.ToString());
            return result.ToArray();
        }

        /// <summary>
        /// Escapes a CSV field by surrounding with quotes if needed.
        /// </summary>
        private static string EscapeCsv(string value)
        {
            if (value == null) value = "";
            if (value.Contains(',') || value.Contains('\"'))
            {
                value = value.Replace("\"", "");
                return "\"" + value + "\"";
            }
            return value;
        }
    }
}
