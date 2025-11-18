using MercaditoMovil.Application.Services;
using MercaditoMovil.Domain.Entities;


namespace MercaditoMovil.Views.WinForms.Controllers
{
    /// <summary>
    /// Controller para el proceso de autenticacion en la vista.
    /// </summary>
    public class LoginController
    {
        private readonly IAuthService _authService;

        public LoginController()
            : this(new AuthService())
        {
        }

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Intenta autenticar un usuario con las credenciales dadas.
        /// </summary>
        public User? SignIn(string email, string password)
        {
            return _authService.IniciarSesion(email, password);
        }
    }
}
