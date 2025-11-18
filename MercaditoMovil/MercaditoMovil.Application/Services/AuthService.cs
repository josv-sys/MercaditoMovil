using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Application.Services
{
    /// <summary>
    /// Servicio de autenticacion basado en lectura de archivo CSV de usuarios.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly string _usersFilePath;

        /// <summary>
        /// Crea una nueva instancia del servicio de autenticacion.
        /// </summary>
        public AuthService()
        {
            // Se asume que la carpeta DataFiles se copia al directorio de salida
            // junto con la estructura People/users.csv.
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            _usersFilePath = Path.Combine(basePath, "DataFiles", "People", "users.csv");
        }

        /// <summary>
        /// Intenta autenticar un usuario segun correo y contrasena.
        /// </summary>
        public User? IniciarSesion(string email, string password)
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

            // Normalizar encabezados
            for (int i = 0; i < headers.Length; i++)
            {
                headers[i] = Limpiar(headers[i]);
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

            // Normalizacion de credenciales de entrada
            string normalizedEmail = Limpiar(email).ToLower();
            string normalizedPassword = Limpiar(password);

            while (!parser.EndOfData)
            {
                string[]? campos = parser.ReadFields();
                if (campos == null)
                {
                    continue;
                }

                string emailCsv = Limpiar(campos[iEmail]).ToLower();
                string passwordCsv = Limpiar(campos[iPassword]);

                if (emailCsv == normalizedEmail && passwordCsv == normalizedPassword)
                {
                    string userId = Limpiar(campos[iUserId]);
                    string username = Limpiar(campos[iUsername]);
                    string firstName = Limpiar(campos[iFirstName]);
                    string lastName1 = Limpiar(campos[iLast1]);
                    string lastName2 = Limpiar(campos[iLast2]);
                    string nationalId = Limpiar(campos[iNationalId]);
                    string phone = Limpiar(campos[iPhone]);
                    string address = Limpiar(campos[iAddress]);
                    string province = Limpiar(campos[iProvince]);
                    string canton = Limpiar(campos[iCanton]);
                    string district = Limpiar(campos[iDistrict]);
                    string marketId = Limpiar(campos[iMarket]);

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

        private static string Limpiar(string? value)
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
