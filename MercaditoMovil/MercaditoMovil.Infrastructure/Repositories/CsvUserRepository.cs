using System.Text;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Interfaces.Repositories;
using System.Diagnostics;


namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// User repository implementation based on a CSV file.
    /// CSV structure (columns):
    /// UserId, Username, Password, FirstName, FirstLastName, SecondLastName,
    /// NationalId, Email, Phone, Address, Province, Canton, District, MarketId
    /// </summary>
    public class CsvUserRepository : IUserRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Creates a repository instance using a specific file path.
        /// </summary>
        public CsvUserRepository(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Creates a repository instance using the default users CSV path.
        /// </summary>
        public CsvUserRepository()
        {
            _filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles",
                "People",
                "users.csv");
        }

        /// <inheritdoc />
        public List<User> GetAll()
        {
            var list = new List<User>();

            if (!File.Exists(_filePath))
            {
                return list;
            }

            string[] lines = File.ReadAllLines(_filePath, Encoding.UTF8);

            // Skip header line.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = SplitCsv(line);
                if (parts.Length < 14)
                {
                    continue;
                }

                // CSV order:
                // 0: UserId
                // 1: Username
                // 2: Password
                // 3: FirstName
                // 4: FirstLastName
                // 5: SecondLastName
                // 6: NationalId
                // 7: Email
                // 8: Phone
                // 9: Address
                // 10: Province
                // 11: Canton
                // 12: District
                // 13: MarketId

                var user = new User(
                    parts[0],
                    parts[1],
                    parts[2],
                    parts[3],
                    parts[4],
                    parts[5],
                    parts[6],
                    parts[7],
                    parts[8],
                    parts[9],
                    parts[10],
                    parts[11],
                    parts[12],
                    parts[13]);

                list.Add(user);
            }

            return list;
        }

        /// <inheritdoc />
        public User? GetByUsername(string username)
        {
            if (username == null)
            {
                return null;
            }

            string normalized = username.Trim();

            List<User> users = GetAll();
            int i = 0;
            while (i < users.Count)
            {
                User user = users[i];
                if (string.Equals(user.Username, normalized, StringComparison.OrdinalIgnoreCase))
                {
                    return user;
                }

                i++;
            }

            return null;
        }

        /// <inheritdoc />
        public bool UsernameExists(string username)
        {
            return GetByUsername(username) != null;
        }

        /// <inheritdoc />
        public bool NationalIdExists(string nationalId)
        {
            if (nationalId == null)
            {
                return false;
            }

            string normalized = nationalId.Trim();

            List<User> users = GetAll();
            int i = 0;
            while (i < users.Count)
            {
                if (string.Equals(users[i].NationalId, normalized, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                i++;
            }

            return false;
        }

        /// <inheritdoc />

        /// <summary>
        /// Adds a new user to the CSV data source.
        /// </summary>
        /// <param name="user">User entity to be persisted.</param>
        /// <returns>The same user instance that was added.</returns>
        public User Add(User user)
        {
            // Ensure target directory exists before writing the file
            string? directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Columns must match the CSV header:
            // UserId, Username, Password, FirstName, FirstLastName, SecondLastName,
            // NationalId, Email, Phone, Address, Province, Canton, District, MarketId
            string[] columns =
            {
                user.UserId,
                user.Username,
                user.Password,
                user.FirstName,
                user.LastName1,
                user.LastName2,
                user.NationalId,
                user.Email,
                user.Phone,
                user.ExactAddress, // Address
                user.Province,
                user.Canton,
                user.District,
                user.MarketId
            };

            // Escape each column to be CSV safe
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = EscapeCsv(columns[i]);
            }

            string line = string.Join(",", columns);

            // Append the new user as a new line in the CSV file
            File.AppendAllText(_filePath, Environment.NewLine + line, Encoding.UTF8);

            return user;
        }



        /// <summary>
        /// Splits a CSV line honoring quoted fields.
        /// </summary>
        private static string[] SplitCsv(string line)
        {
            var result = new List<string>();
            var builder = new StringBuilder();
            bool inQuotes = false;
            int i = 0;

            while (i < line.Length)
            {
                char c = line[i];

                if (c == '\"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(builder.ToString());
                    builder.Clear();
                }
                else
                {
                    builder.Append(c);
                }

                i++;
            }

            result.Add(builder.ToString());
            return result.ToArray();
        }

        /// <summary>
        /// Escapes a CSV field adding quotes when needed.
        /// </summary>
        private static string EscapeCsv(string? value)
        {
            value ??= string.Empty;

            if (value.Contains(',') || value.Contains('\"'))
            {
                string cleaned = value.Replace("\"", string.Empty);
                return "\"" + cleaned + "\"";
            }

            return value;
        }
    }
}
