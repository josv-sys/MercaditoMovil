using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Domain.Interfaces
{
    /// <summary>
    /// Repository abstraction for producers.
    /// </summary>
    public interface IProducerRepository
    {
        /// <summary>
        /// Returns all producers.
        /// </summary>
        List<Producer> GetAll();

        /// <summary>
        /// Returns a producer by its identifier or null when it does not exist.
        /// </summary>
        Producer GetById(string producerId);
    }
}
