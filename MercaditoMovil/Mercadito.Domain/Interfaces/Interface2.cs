using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Domain.Interfaces
{
    /// <summary>
    /// Repository abstraction for markets.
    /// </summary>
    public interface IMarketRepository
    {
        /// <summary>
        /// Returns all markets.
        /// </summary>
        List<Market> GetAll();

        /// <summary>
        /// Returns a market by its identifier or null when it does not exist.
        /// </summary>
        Market GetById(string marketId);
    }
}
