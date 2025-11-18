using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Interfaces;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio que combina catalogo y disponibilidad para exponer productos listos para venta.
    /// </summary>
    public class ProductAvailabilityRepository : IProductRepository
    {
        private readonly ProductCatalogRepository _catalogRepository;
        private readonly ProducerProductsRepository _producerProductsRepository;

        public ProductAvailabilityRepository()
        {
            _catalogRepository = new ProductCatalogRepository();
            _producerProductsRepository = new ProducerProductsRepository();
        }

        /// <inheritdoc/>
        public List<Product> GetByMarket(string marketId)
        {
            // En esta iteracion el parametro marketId no se utiliza,
            // porque el archivo de disponibilidad no contiene campo de mercado.
            var catalog = _catalogRepository.GetAll();
            var availability = _producerProductsRepository.GetAvailability();

            var result = new List<Product>();

            int i = 0;
            while (i < catalog.Count)
            {
                Product catalogProduct = catalog[i];

                int j = 0;
                while (j < availability.Count)
                {
                    var a = availability[j];

                    if (a.ProductCatalogId == catalogProduct.ProductCatalogId)
                    {
                        var product = new Product
                        {
                            ProductCatalogId = catalogProduct.ProductCatalogId,
                            Name = catalogProduct.Name,
                            Unit = catalogProduct.Unit,
                            IsActive = catalogProduct.IsActive,
                            Price = a.Price,
                            Stock = a.Stock,
                            Packaging = a.Packaging
                        };

                        result.Add(product);
                    }

                    j++;
                }

                i++;
            }

            return result;
        }

        /// <inheritdoc/>
        public Product GetByCatalogId(string productCatalogId)
        {
            if (productCatalogId == null)
            {
                return null;
            }

            string normalized = productCatalogId.Trim();

            List<Product> products = GetByMarket(string.Empty);

            int i = 0;
            while (i < products.Count)
            {
                if (products[i].ProductCatalogId == normalized)
                {
                    return products[i];
                }

                i++;
            }

            return null;
        }
    }
}