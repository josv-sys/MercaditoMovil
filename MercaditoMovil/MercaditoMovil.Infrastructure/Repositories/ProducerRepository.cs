using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Interfaces;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio de productores basado en archivo CSV.
    /// </summary>
    public class ProducerRepository : IProducerRepository
    {
        private readonly string _file;

        public ProducerRepository()
        {
            _file = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles",
                "Producers",
                "producers.csv");
        }

        /// <inheritdoc/>
        public List<Producer> GetAll()
        {
            var list = new List<Producer>();

            if (!File.Exists(_file))
            {
                return list;
            }

            string[] lines = File.ReadAllLines(_file);

            // Omitir encabezado.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(',');
                if (parts.Length < 8)
                {
                    continue;
                }

                var producer = new Producer
                {
                    ProducerId = parts[0].Trim(),
                    ProducerCode = parts[1].Trim(),
                    NationalId = parts[2].Trim(),
                    Name = parts[3].Trim(),
                    Email = parts[4].Trim(),
                    Phone = parts[5].Trim(),
                    MarketId = parts[6].Trim(),
                    UserId = parts[7].Trim(),
                    IsActive = true
                };

                list.Add(producer);
            }

            return list;
        }

        /// <inheritdoc/>
        public Producer GetById(string producerId)
        {
            if (producerId == null)
            {
                return null;
            }

            string normalized = producerId.Trim();

            List<Producer> producers = GetAll();
            int i = 0;
            while (i < producers.Count)
            {
                if (producers[i].ProducerId == normalized)
                {
                    return producers[i];
                }

                i++;
            }

            return null;
        }
    }
}
