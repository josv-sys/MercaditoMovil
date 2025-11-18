using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Domain.Interfaces
{
    /// <summary>
    /// Repositorio de ferias o mercados.
    /// </summary>
    public interface IMarketRepository
    {
        /// <summary>
        /// Devuelve todas las ferias registradas.
        /// </summary>
        List<Market> GetAll();

        /// <summary>
        /// Devuelve una feria por su identificador o null cuando no existe.
        /// </summary>
        Market GetById(string marketId);
    }
}
