using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Domain.Interfaces
{
    /// <summary>
    /// Repositorio de productos.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Devuelve todos los productos disponibles para un mercado.
        /// </summary>
        List<Product> GetByMarket(string marketId);

        /// <summary>
        /// Devuelve un producto por su identificador de catalogo o null cuando no existe.
        /// </summary>
        Product GetByCatalogId(string productCatalogId);
    }
}
