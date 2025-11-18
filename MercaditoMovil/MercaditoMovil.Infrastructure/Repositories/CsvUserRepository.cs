using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Interfaces;
using MercaditoMovil.Domain.Interfaces.Repositories;
using System.Text;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio de usuarios basado en archivo CSV.
    /// </summary>
    public class CsvUserRepository : IUserRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Crea una instancia del repositorio usando una ruta especifica.
        /// </summary>
        public CsvUserRepository(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Crea una instancia del repositorio usando la ruta por defecto.
        /// </summary>
        public CsvUserRepository()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            _filePath = Path.Combine(basePath, "DataFiles", "People", "users.csv");
        }

        /// <inheritdoc/>
        public List<User> GetAll()
        {
            var list = new List<User>();

            if (!File.Exists(_filePath))
            {
                return list;
            }

            string[] lines = File.ReadAllLines(_filePath, Encoding.UTF8);

            // Se omite la primera linea (encabezados).
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

        /// <inheritdoc/>
        public User GetByUsername(string username)
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

        /// <inheritdoc/>
        public bool UsernameExists(string username)
        {
            return GetByUsername(username) != null;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public User Add(User user)
        {
            // Se asume que el archivo ya existe y contiene la cabecera.
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
                user.Province,
                user.Canton,
                user.District,
                user.ExactAddress,
                user.MarketId
            };

            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = EscapeCsv(columns[i]);
            }

            string line = string.Join(",", columns);
            File.AppendAllText(_filePath, Environment.NewLine + line, Encoding.UTF8);

            return user;
        }

        /// <summary>
        /// Divide una linea CSV respetando comillas.
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
        /// Escapa un campo CSV agregando comillas cuando es necesario.
        /// </summary>
        private static string EscapeCsv(string value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            if (value.Contains(',') || value.Contains('\"'))
            {
                string cleaned = value.Replace("\"", string.Empty);
                return "\"" + cleaned + "\"";
            }

            return value;
        }
    }
}
