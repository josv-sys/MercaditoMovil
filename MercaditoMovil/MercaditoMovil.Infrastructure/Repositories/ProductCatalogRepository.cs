using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Reads the general product catalog information.
    /// This catalog does NOT create Product objects because Product
    /// is created from producer_products.csv (availability file).
    /// </summary>
    public class ProductCatalogRepository
    {
        private readonly string _filePath;

        public ProductCatalogRepository()
        {
            _filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles",
                "Catalogs",
                "product_catalog.csv");
        }

        /// <summary>
        /// Returns the internal catalog as dictionary: catalogId -> name.
        /// </summary>
        public Dictionary<string, string> GetCatalog()
        {
            var dict = new Dictionary<string, string>();

            if (!File.Exists(_filePath))
                return dict;

            string[] lines = File.ReadAllLines(_filePath, Encoding.UTF8);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] c = line.Split(',');

                string id = c[0];
                string name = c[1];

                if (!dict.ContainsKey(id))
                    dict.Add(id, name);
            }

            return dict;
        }
    }
}




