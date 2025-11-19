using System;
using System.Collections.Generic;
using System.IO;
using MercaditoMovil.Domain.Interfaces;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Location repository based on the locations CSV file.
    /// </summary>
    public class LocationRepository : ILocationRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Creates a new repository using the default locations file.
        /// </summary>
        public LocationRepository()
        {
            // Use the directory of this assembly (Infrastructure) instead of the exe directory.
            string assemblyLocation = typeof(LocationRepository).Assembly.Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation)
                                       ?? AppDomain.CurrentDomain.BaseDirectory;

            _filePath = Path.Combine(
                assemblyDirectory,
                "DataFiles",
                "Locations",
                "locations.csv");
        }

        /// <inheritdoc />
        public List<string> GetProvinces()
        {
            var provinces = new List<string>();

            if (!File.Exists(_filePath))
            {
                return provinces;
            }

            string[] lines = File.ReadAllLines(_filePath);

            // Skip header line.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = SplitLine(line);
                if (parts.Length < 6)
                {
                    continue;
                }

                // ProvinceName is at position 1.
                string provinceName = parts[1].Trim();

                bool exists = false;
                int j = 0;
                while (j < provinces.Count)
                {
                    if (string.Equals(provinces[j], provinceName, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }

                    j++;
                }

                if (!exists)
                {
                    provinces.Add(provinceName);
                }
            }

            return provinces;
        }

        /// <inheritdoc />
        public List<string> GetCantons(string province)
        {
            var cantons = new List<string>();

            if (!File.Exists(_filePath))
            {
                return cantons;
            }

            province ??= string.Empty;
            province = province.Trim();

            string[] lines = File.ReadAllLines(_filePath);

            // Skip header line.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = SplitLine(line);
                if (parts.Length < 6)
                {
                    continue;
                }

                string provinceName = parts[1].Trim(); // ProvinceName
                string cantonName = parts[3].Trim();   // CantonName

                if (!string.Equals(provinceName, province, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                bool exists = false;
                int j = 0;
                while (j < cantons.Count)
                {
                    if (string.Equals(cantons[j], cantonName, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }

                    j++;
                }

                if (!exists)
                {
                    cantons.Add(cantonName);
                }
            }

            return cantons;
        }

        /// <inheritdoc />
        public List<string> GetDistricts(string province, string canton)
        {
            var districts = new List<string>();

            if (!File.Exists(_filePath))
            {
                return districts;
            }

            province ??= string.Empty;
            canton ??= string.Empty;
            province = province.Trim();
            canton = canton.Trim();

            string[] lines = File.ReadAllLines(_filePath);

            // Skip header line.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = SplitLine(line);
                if (parts.Length < 6)
                {
                    continue;
                }

                string provinceName = parts[1].Trim(); // ProvinceName
                string cantonName = parts[3].Trim();   // CantonName
                string districtName = parts[5].Trim(); // DistrictName

                if (!string.Equals(provinceName, province, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!string.Equals(cantonName, canton, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                bool exists = false;
                int j = 0;
                while (j < districts.Count)
                {
                    if (string.Equals(districts[j], districtName, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }

                    j++;
                }

                if (!exists)
                {
                    districts.Add(districtName);
                }
            }

            return districts;
        }

        /// <summary>
        /// Splits a CSV line trying ';', ',' and tab, using the first option that gives at least 6 columns.
        /// </summary>
        private static string[] SplitLine(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length >= 6)
            {
                return parts;
            }

            parts = line.Split(',');
            if (parts.Length >= 6)
            {
                return parts;
            }

            parts = line.Split('\t');
            return parts;
        }
    }
}
