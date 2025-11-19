using MercaditoMovil.Application.Services;
using MercaditoMovil.Domain.Interfaces;
using MercaditoMovil.Domain.Interfaces.Repositories;
using MercaditoMovil.Infrastructure.Repositories;
using MercaditoMovil.Views.WinForms.Models;
using System;
using System.Collections.Generic;

namespace MercaditoMovil.Views.WinForms.Controllers
{
    /// <summary>
    /// Controller for handling registration actions.
    /// Wraps location repository and user registration service.
    /// </summary>
    public class RegistrationController
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IUserRegistrationService _registrationService;

        public RegistrationController()
        {
            _locationRepository = new LocationRepository();
            _registrationService = new UserRegistrationService(); // CORRECTO
        }

        public List<string> GetProvinces()
        {
            return _locationRepository.GetProvinces();
        }

        public List<string> GetCantons(string province)
        {
            return _locationRepository.GetCantons(province);
        }

        public List<string> GetDistricts(string province, string canton)
        {
            return _locationRepository.GetDistricts(province, canton);
        }

        public bool Register(RegistrationViewModel model, out List<string> messages)
        {
            var user = _registrationService.RegisterUser(
                model.FirstName,
                model.LastName1,
                model.LastName2,
                model.NationalId,
                model.Email,
                model.Phone,
                model.Username,
                model.Password,
                model.Province,
                model.Canton,
                model.District,
                model.Address,
                out messages);

            return user != null;
        }
    }
}
