using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Loads and updates product availability from producer_products.csv.
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

        /// <summary>
        /// Returns all products with current stock.
        /// </summary>
        public List<Product> GetAll()
        {
            var list = new List<Product>();

            if (!File.Exists(_filePath))
                return list;

            string[] lines = File.ReadAllLines(_filePath, Encoding.UTF8);
            Dictionary<string, string> catalog = _catalogRepo.GetCatalog();

            // Skip header (index 0)
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] c = line.Split(',');
                if (c.Length < 18)
                    continue;

                string producerId = c[1].Trim();
                string catalogId = c[2].Trim();

                decimal price;
                if (!decimal.TryParse(
                        c[3],
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out price))
                {
                    price = 0;
                }

                string packaging = c[6].Trim();

                int stock;
                if (!int.TryParse(c[13].Trim(), out stock))
                    stock = 0;

                string productName;
                if (catalog.ContainsKey(catalogId))
                    productName = catalog[catalogId];
                else
                    productName = "Producto";

                // For now, unit is the same as packaging
                string unit = packaging;

                Product p = new Product(
                    catalogId,
                    producerId,
                    productName,
                    unit,
                    packaging,
                    price,
                    stock);

                list.Add(p);
            }

            return list;
        }

        /// <summary>
        /// Decreases stock for a given producer and catalog id in the CSV file.
        /// </summary>
        public void DecreaseStock(string producerId, string productCatalogId, int quantity)
        {
            if (!File.Exists(_filePath))
                return;

            if (quantity <= 0)
                return;

            string producerKey = (producerId ?? string.Empty).Trim();
            string catalogKey = (productCatalogId ?? string.Empty).Trim();

            string[] lines = File.ReadAllLines(_filePath, Encoding.UTF8);
            bool updated = false;

            // Debug info to Output window
            Debug.WriteLine("=== DecreaseStock called ===");
            Debug.WriteLine("ProducerId param = [" + producerKey + "]");
            Debug.WriteLine("CatalogId param  = [" + catalogKey + "]");
            Debug.WriteLine("Quantity         = " + quantity);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] c = line.Split(',');
                if (c.Length < 18)
                    continue;

                string csvProducerId = c[1].Trim();
                string csvCatalogId = c[2].Trim();

                if (string.Equals(csvProducerId, producerKey, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(csvCatalogId, catalogKey, StringComparison.OrdinalIgnoreCase))
                {
                    int currentStock;
                    if (!int.TryParse(c[13].Trim(), out currentStock))
                        currentStock = 0;

                    int newStock = currentStock - quantity;
                    if (newStock < 0)
                        newStock = 0;

                    Debug.WriteLine("Match found on line " + i);
                    Debug.WriteLine("Current stock = " + currentStock + ", new stock = " + newStock);

                    c[13] = newStock.ToString(CultureInfo.InvariantCulture);
                    lines[i] = string.Join(",", c);
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                File.WriteAllLines(_filePath, lines, Encoding.UTF8);
                Debug.WriteLine("CSV updated successfully.");
            }
            else
            {
                Debug.WriteLine("No matching row found for stock update.");
            }

            Debug.WriteLine("=== DecreaseStock finished ===");
        }

        /// <summary>
        /// Returns current stock for a given producer and catalog identifier.
        /// Returns 0 when the product is not found or stock is invalid.
        /// </summary>
        public int GetStock(string producerId, string productCatalogId)
        {
            if (!File.Exists(_filePath))
            {
                return 0;
            }

            string[] lines = File.ReadAllLines(_filePath);

            // Skip header line.
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

                string fileProducerId = parts[1].Trim();
                string fileCatalogId = parts[2].Trim();

                if (fileProducerId == producerId && fileCatalogId == productCatalogId)
                {
                    int stock;
                    if (int.TryParse(parts[13], out stock))
                    {
                        return stock;
                    }

                    return 0;
                }
            }

            return 0;
        }

    }
}

