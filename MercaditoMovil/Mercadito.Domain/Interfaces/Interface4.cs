using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Domain.Interfaces
{
    /// <summary>
    /// Repositorio de productores.
    /// </summary>
    public interface IProducerRepository
    {
        /// <summary>
        /// Devuelve todos los productores registrados.
        /// </summary>
        List<Producer> GetAll();

        /// <summary>
        /// Devuelve un productor por su identificador o null cuando no existe.
        /// </summary>
        Producer GetById(string producerId);
    }
}
