using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace MercaditoMovil.Domain.Interfaces
{
    /// <summary>
    /// Repository abstraction for reading location data (province, canton, district).
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Returns the list of available provinces.
        /// </summary>
        List<string> GetProvinces();

        /// <summary>
        /// Returns the list of cantons for the given province.
        /// </summary>
        /// <param name="province">Province name.</param>
        List<string> GetCantons(string province);

        /// <summary>
        /// Returns the list of districts for the given province and canton.
        /// </summary>
        /// <param name="province">Province name.</param>
        /// <param name="canton">Canton name.</param>
        List<string> GetDistricts(string province, string canton);
    }
}
