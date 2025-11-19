using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Application.Services.Interfaces;

namespace MercaditoMovil.Application.Services
{
    /// <summary>
    /// Authentication service based on the users CSV file.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly string _usersFilePath;

        /// <summary>
        /// Creates a new instance of the authentication service.
        /// </summary>
        public AuthService()
        {
            // DataFiles folder must be copied to the output directory.
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            _usersFilePath = Path.Combine(basePath, "DataFiles", "People", "users.csv");
        }

        /// <inheritdoc />
        public User? SignIn(string email, string password)
        {
            if (!File.Exists(_usersFilePath))
            {
                return null;
            }

            using var parser = new TextFieldParser(_usersFilePath);
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;

            string[]? headers = parser.ReadFields();
            if (headers == null)
            {
                return null;
            }

            for (int i = 0; i < headers.Length; i++)
            {
                headers[i] = CleanField(headers[i]);
            }

            int iUserId = Array.IndexOf(headers, "UserId");
            int iUsername = Array.IndexOf(headers, "Username");
            int iPassword = Array.IndexOf(headers, "Password");
            int iFirstName = Array.IndexOf(headers, "FirstName");
            int iLast1 = Array.IndexOf(headers, "FirstLastName");
            int iLast2 = Array.IndexOf(headers, "SecondLastName");
            int iNationalId = Array.IndexOf(headers, "NationalId");
            int iEmail = Array.IndexOf(headers, "Email");
            int iPhone = Array.IndexOf(headers, "Phone");
            int iAddress = Array.IndexOf(headers, "Address");
            int iProvince = Array.IndexOf(headers, "Province");
            int iCanton = Array.IndexOf(headers, "Canton");
            int iDistrict = Array.IndexOf(headers, "District");
            int iMarket = Array.IndexOf(headers, "MarketId");

            string normalizedEmail = CleanField(email).ToLower();
            string normalizedPassword = CleanField(password);

            while (!parser.EndOfData)
            {
                string[]? fields = parser.ReadFields();
                if (fields == null)
                {
                    continue;
                }

                string emailCsv = CleanField(fields[iEmail]).ToLower();
                string passwordCsv = CleanField(fields[iPassword]);

                if (emailCsv == normalizedEmail && passwordCsv == normalizedPassword)
                {
                    string userId = CleanField(fields[iUserId]);
                    string username = CleanField(fields[iUsername]);
                    string firstName = CleanField(fields[iFirstName]);
                    string lastName1 = CleanField(fields[iLast1]);
                    string lastName2 = CleanField(fields[iLast2]);
                    string nationalId = CleanField(fields[iNationalId]);
                    string phone = CleanField(fields[iPhone]);
                    string address = CleanField(fields[iAddress]);
                    string province = CleanField(fields[iProvince]);
                    string canton = CleanField(fields[iCanton]);
                    string district = CleanField(fields[iDistrict]);
                    string marketId = CleanField(fields[iMarket]);

                    var user = new User(
                        userId,
                        username,
                        passwordCsv,
                        firstName,
                        lastName1,
                        lastName2,
                        nationalId,
                        emailCsv,
                        phone,
                        province,
                        canton,
                        district,
                        address,
                        marketId);

                    return user;
                }
            }

            return null;
        }

        /// <summary>
        /// Normalizes a raw CSV field.
        /// </summary>
        private static string CleanField(string? value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value
                .Replace("\"", string.Empty)
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty)
                .Trim();
        }
    }
}