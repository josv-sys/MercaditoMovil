using System;
using System.Collections.Generic;
using System.IO;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Infrastructure.Repositories;

namespace MercaditoMovil.Application.Services
{
    /// <summary>
    /// Servicio para administrar el carrito de compras de un usuario.
    /// </summary>
    public class CartService
    {
        private readonly User _user;
        private readonly MarketRepository _marketRepository;
        private readonly ProductAvailabilityRepository _availabilityRepository;

        private readonly List<(Product product, int quantity)> _cart = new();
        private List<Product>? _availableProducts;

        /// <summary>
        /// Crea una instancia del servicio de carrito para un usuario especifico.
        /// </summary>
        public CartService(User user)
        {
            _user = user;
            _marketRepository = new MarketRepository();
            _availabilityRepository = new ProductAvailabilityRepository();
        }

        /// <summary>
        /// Obtiene la feria asignada al usuario.
        /// </summary>
        public Market? ObtenerFeria()
        {
            return _marketRepository.GetById(_user.MarketId);
        }

        /// <summary>
        /// Obtiene la lista de productos disponibles para la feria del usuario.
        /// </summary>
        public List<Product> ObtenerProductos()
        {
            if (_availableProducts == null)
            {
                _availableProducts = _availabilityRepository.GetByMarket(_user.MarketId);
            }

            return _availableProducts;
        }

        /// <summary>
        /// Devuelve los elementos actuales del carrito.
        /// </summary>
        public List<(Product product, int quantity)> ObtenerCarrito()
        {
            return _cart;
        }

        /// <summary>
        /// Agrega un producto al carrito si hay stock suficiente.
        /// </summary>
        public void Agregar(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception("La cantidad debe ser mayor a cero.");
            }

            if (product.Stock < quantity)
            {
                throw new Exception("No hay suficiente stock disponible.");
            }

            product.Stock -= quantity;

            int index = -1;
            for (int i = 0; i < _cart.Count; i++)
            {
                if (_cart[i].product.ProductCatalogId == product.ProductCatalogId)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                var line = _cart[index];
                _cart[index] = (line.product, line.quantity + quantity);
            }
            else
            {
                _cart.Add((product, quantity));
            }
        }

        /// <summary>
        /// Quita un elemento del carrito y devuelve su stock al producto.
        /// </summary>
        public void Quitar((Product product, int quantity) item)
        {
            item.product.Stock += item.quantity;
            _cart.Remove(item);
        }

        /// <summary>
        /// Registra la compra en un archivo CSV y limpia el carrito.
        /// </summary>
        public bool FinalizarCompra()
        {
            if (_cart.Count == 0)
            {
                return false;
            }

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string folder = Path.Combine(basePath, "DataFiles", "Invoices");

            Directory.CreateDirectory(folder);

            string filePath = Path.Combine(folder, "registro_compras.csv");
            bool isNew = !File.Exists(filePath);

            using (var writer = new StreamWriter(filePath, append: true))
            {
                if (isNew)
                {
                    writer.WriteLine("Fecha,Usuario,Feria,Producto,Cantidad,PrecioUnitario,TotalLinea");
                }

                Market? market = ObtenerFeria();
                string marketName = market != null ? market.Name : "No Asignada";
                string userName = $"{_user.FirstName} {_user.LastName1} {_user.LastName2}".Trim();

                foreach (var item in _cart)
                {
                    decimal total = item.product.Price * item.quantity;

                    writer.WriteLine(
                        $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}," +
                        $"{userName}," +
                        $"{marketName}," +
                        $"{item.product.Name}," +
                        $"{item.quantity}," +
                        $"{item.product.Price}," +
                        $"{total}");
                }
            }

            _cart.Clear();
            return true;
        }
    }
}
