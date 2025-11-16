using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MercaditoMovil.Infrastructure.Repositories
{
    public class ProducerProductsRepository
    {
        private readonly string _file;

        public ProducerProductsRepository()
        {
            _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles", "Commerce", "producer_products.csv");
        }

        public List<(string ProductCatalogId, decimal Price, int Stock, string Packaging)> GetAvailability()
        {
            var result = new List<(string, decimal, int, string)>();

            if (!File.Exists(_file))
                return result;

            var lines = File.ReadAllLines(_file).Skip(1);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length < 18)
                    continue;

                string catalogId = parts[2].Trim();
                string packaging = parts[6].Trim(); // PACKAGING ES COLUMNA 7 (ÍNDICE 6)

                // Precio
                decimal price = 0;
                decimal.TryParse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out price);

                // Stock
                int stock = 0;
                if (!int.TryParse(parts[13], out stock))
                    stock = 1;

                // Activo
                bool active = parts[17].Trim().ToLower() == "true";
                if (!active)
                    continue;

                result.Add((catalogId, price, stock, packaging));
            }

            return result;
        }
    }
}





