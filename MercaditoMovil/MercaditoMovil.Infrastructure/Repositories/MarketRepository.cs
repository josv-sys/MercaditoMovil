using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Domain.Interfaces;

namespace MercaditoMovil.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio de ferias basado en archivo CSV.
    /// </summary>
    public class MarketRepository : IMarketRepository
    {
        private readonly string _file;

        public MarketRepository()
        {
            _file = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles",
                "Markets",
                "markets.csv");
        }

        /// <inheritdoc/>
        public List<Market> GetAll()
        {
            var markets = new List<Market>();

            if (!File.Exists(_file))
            {
                return markets;
            }

            string[] lines = File.ReadAllLines(_file);

            // Se omite encabezado.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(',');
                if (parts.Length < 5)
                {
                    continue;
                }

                var market = new Market
                {
                    MarketId = parts[0].Trim(),
                    Name = parts[1].Trim(),
                    Province = parts[2].Trim(),
                    Canton = parts[3].Trim(),
                    District = parts[4].Trim()
                };

                markets.Add(market);
            }

            return markets;
        }

        /// <inheritdoc/>
        public Market GetById(string marketId)
        {
            if (marketId == null)
            {
                return null;
            }

            string normalized = marketId.Trim();

            List<Market> markets = GetAll();
            int i = 0;
            while (i < markets.Count)
            {
                if (markets[i].MarketId == normalized)
                {
                    return markets[i];
                }

                i++;
            }

            return null;
        }
    }
}
