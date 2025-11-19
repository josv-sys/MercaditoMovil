using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Domain.Interfaces
{
    /// <summary>
    /// Repository abstraction for products.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Returns all products available for the given market.
        /// </summary>
        List<Product> GetByMarket(string marketId);

        /// <summary>
        /// Returns a product by its catalog identifier or null when it does not exist.
        /// </summary>
        Product GetByCatalogId(string productCatalogId);
    }
}
