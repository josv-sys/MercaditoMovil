using System.Globalization;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Reads producer product availability from a CSV file.
    /// </summary>
    public class ProducerProductsRepository
    {
        private readonly string _file;

        public ProducerProductsRepository()
        {
            _file = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles",
                "Commerce",
                "producer_products.csv");
        }

        /// <summary>
        /// Returns product availability by catalog identifier.
        /// </summary>
        public List<(string ProductCatalogId, decimal Price, int Stock, string Packaging)> GetAvailability()
        {
            var result = new List<(string, decimal, int, string)>();

            if (!File.Exists(_file))
            {
                return result;
            }

            string[] lines = File.ReadAllLines(_file);

            // Skip header.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(',');
                if (parts.Length < 18)
                {
                    continue;
                }

                string catalogId = parts[2].Trim();
                string packaging = parts[6].Trim();

                decimal price;
                if (!decimal.TryParse(
                        parts[3],
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out price))
                {
                    price = 0;
                }

                int stock;
                if (!int.TryParse(parts[13], out stock))
                {
                    stock = 1;
                }

                bool active = parts[17].Trim().ToLower() == "true";
                if (!active)
                {
                    continue;
                }

                result.Add((catalogId, price, stock, packaging));
            }

            return result;
        }
    }
}

