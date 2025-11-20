namespace MercaditoMovil.Domain.Entities
{
    /// <summary>
    /// Registered user with main profile and location information.
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
        public string ExactAddress { get; }  
        public string Province { get; }
        public string Canton { get; }
        public string District { get; }
        public string MarketId { get; }

        /// <summary>
        /// Creates a new user instance normalizing null values and trimming spaces.
        /// Matching EXACT CSV order.
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
            string exactAddress,  
            string province,
            string canton,
            string district,
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
            exactAddress ??= string.Empty;
            province ??= string.Empty;
            canton ??= string.Empty;
            district ??= string.Empty;
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
            ExactAddress = exactAddress.Trim(); // posicion corregida
            Province = province.Trim();
            Canton = canton.Trim();
            District = district.Trim();
            MarketId = marketId.Trim();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName1} {LastName2}".Trim();
        }
    }
}
