using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Loads product availability from producer_products.csv.
    /// Adapted to the real CSV structure.
    /// </summary>
    public class ProductAvailabilityRepository
    {
        private readonly string _filePath;
        private readonly ProductCatalogRepository _catalogRepo = new ProductCatalogRepository();

        public ProductAvailabilityRepository()
        {
            _filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles",
                "Commerce",
                "producer_products.csv");
        }

        public List<Product> GetAll()
        {
            var list = new List<Product>();

            if (!File.Exists(_filePath))
                return list;

            string[] lines = File.ReadAllLines(_filePath, Encoding.UTF8);

            var catalog = _catalogRepo.GetCatalog(); // catalogId -> name

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] c = line.Split(',');

                string producerId = c[1];
                string catalogId = c[2];
                decimal price = decimal.Parse(c[3]);
                string packaging = c[6];
                int stock = int.Parse(c[13]);

                string productName = catalog.ContainsKey(catalogId)
                    ? catalog[catalogId]
                    : "Producto";

                // Use packaging as Unit (closest real value)
                string unit = packaging;

                Product p = new Product(
                    catalogId,
                    producerId,
                    productName,
                    unit,
                    packaging,
                    price,
                    stock
                );

                list.Add(p);
            }

            return list;
        }
    }
}
