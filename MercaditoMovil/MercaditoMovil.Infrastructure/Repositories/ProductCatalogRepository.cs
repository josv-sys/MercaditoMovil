using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio del catalogo base de productos.
    /// </summary>
    public class ProductCatalogRepository
    {
        private readonly string _file;

        public ProductCatalogRepository()
        {
            _file = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles",
                "Catalogs",
                "product_catalog.csv");
        }

        /// <summary>
        /// Devuelve todos los productos del catalogo base.
        /// </summary>
        public List<Product> GetAll()
        {
            var list = new List<Product>();

            if (!File.Exists(_file))
            {
                return list;
            }

            string[] lines = File.ReadAllLines(_file);

            // Omitir encabezado.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(',');
                if (parts.Length < 4)
                {
                    continue;
                }

                var product = new Product
                {
                    ProductCatalogId = parts[0].Trim(),
                    Name = parts[1].Trim(),
                    Unit = parts[2].Trim(),
                    IsActive = parts[3].Trim().ToLower() == "true",
                    Price = 0,
                    Stock = 0,
                    Packaging = string.Empty
                };

                list.Add(product);
            }

            return list;
        }
    }
}


