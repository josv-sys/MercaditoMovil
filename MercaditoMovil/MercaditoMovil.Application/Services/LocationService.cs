using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using MercaditoMovil.Domain.Interfaces;
using MercaditoMovil.Infrastructure.Repositories;

namespace MercaditoMovil.Application.Services
{
    /// <summary>
    /// Provides location information for registration forms.
    /// </summary>
    public class LocationService
    {
        private readonly ILocationRepository _locationRepository;

        /// <summary>
        /// Creates a new instance using the default CSV repository.
        /// </summary>
        public LocationService()
        {
            _locationRepository = new LocationRepository();
        }

        /// <summary>
        /// Returns the list of provinces.
        /// </summary>
        public List<string> GetProvinces()
        {
            return _locationRepository.GetProvinces();
        }

        /// <summary>
        /// Returns the list of cantons for a province.
        /// </summary>
        public List<string> GetCantons(string province)
        {
            return _locationRepository.GetCantons(province);
        }

        /// <summary>
        /// Returns the list of districts for a province and canton.
        /// </summary>
        public List<string> GetDistricts(string province, string canton)
        {
            return _locationRepository.GetDistricts(province, canton);
        }
    }
}
