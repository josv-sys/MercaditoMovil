namespace MercaditoMovil.Views.WinForms.Models
{
    /// <summary>
    /// Represents the data entered by the user in the registration form.
    /// </summary>
    public class RegistrationViewModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName1 { get; set; } = string.Empty;
        public string LastName2 { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
