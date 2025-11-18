namespace MercaditoMovil.Domain.Entities
{
    /// <summary>
    /// Usuario registrado en el sistema con sus datos principales.
    /// </summary>
    public class User
    {
        public string UserId { get; }
        public string Username { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName1 { get; }
        public string LastName2 { get; }
        public string NationalId { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Province { get; }
        public string Canton { get; }
        public string District { get; }
        public string ExactAddress { get; }
        public string MarketId { get; }

        /// <summary>
        /// Crea una instancia de usuario normalizando valores nulos y espacios.
        /// </summary>
        public User(
            string userId,
            string username,
            string password,
            string firstName,
            string lastName1,
            string lastName2,
            string nationalId,
            string email,
            string phone,
            string province,
            string canton,
            string district,
            string exactAddress,
            string marketId)
        {
            userId ??= string.Empty;
            username ??= string.Empty;
            password ??= string.Empty;
            firstName ??= string.Empty;
            lastName1 ??= string.Empty;
            lastName2 ??= string.Empty;
            nationalId ??= string.Empty;
            email ??= string.Empty;
            phone ??= string.Empty;
            province ??= string.Empty;
            canton ??= string.Empty;
            district ??= string.Empty;
            exactAddress ??= string.Empty;
            marketId ??= string.Empty;

            UserId = userId.Trim();
            Username = username.Trim();
            Password = password.Trim();
            FirstName = firstName.Trim();
            LastName1 = lastName1.Trim();
            LastName2 = lastName2.Trim();
            NationalId = nationalId.Trim();
            Email = email.Trim();
            Phone = phone.Trim();
            Province = province.Trim();
            Canton = canton.Trim();
            District = district.Trim();
            ExactAddress = exactAddress.Trim();
            MarketId = marketId.Trim();
        }
    }
}
