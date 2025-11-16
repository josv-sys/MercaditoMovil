using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Infrastructure.Repositories;

namespace MercaditoMovil.Application.Services
{
    public class CarritoService
    {
        private readonly Usuario _usuario;
        private readonly MarketRepository _marketRepo;
        private readonly ProductAvailabilityRepository _availabilityRepo;

        // 🛒 Carrito con cantidad
        private readonly List<(Producto producto, int cantidad)> _carrito = new();

        // 🔥 Lista de productos cargada UNA sola vez (para stock en tiempo real)
        private List<Producto>? _productosDisponibles;

        public CarritoService(Usuario usuario)
        {
            _usuario = usuario;
            _marketRepo = new MarketRepository();
            _availabilityRepo = new ProductAvailabilityRepository();
        }

        // -------------------------
        // FERIA DEL USUARIO
        // -------------------------
        public Feria? ObtenerFeria()
            => _marketRepo.GetById(_usuario.MarketId);

        // -------------------------
        // PRODUCTOS DISPONIBLES
        // -------------------------
        public List<Producto> ObtenerProductos()
        {
            // 👇 Solo se leen del CSV una vez
            if (_productosDisponibles == null)
            {
                _productosDisponibles = _availabilityRepo.GetByMarket(_usuario.MarketId);
            }

            return _productosDisponibles;
        }

        // -------------------------
        // CARRITO
        // -------------------------
        public List<(Producto producto, int cantidad)> ObtenerCarrito()
            => _carrito;

        public void Agregar(Producto p, int cantidad)
        {
            if (cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");

            if (p.Stock < cantidad)
                throw new Exception("No hay suficiente stock disponible.");

            // 🔻 Descontamos stock en el MISMO objeto en memoria
            p.Stock -= cantidad;

            // Opcional: agrupar en el carrito si ya existe el producto
            var existenteIndex = _carrito.FindIndex(x => x.producto.ProductCatalogId == p.ProductCatalogId);
            if (existenteIndex >= 0)
            {
                var existente = _carrito[existenteIndex];
                _carrito[existenteIndex] = (existente.producto, existente.cantidad + cantidad);
            }
            else
            {
                _carrito.Add((p, cantidad));
            }
        }

        public void Quitar((Producto producto, int cantidad) item)
        {
            // 🔺 Devolver stock
            item.producto.Stock += item.cantidad;

            // Quitar del carrito
            _carrito.Remove(item);
        }

        // -------------------------
        // FINALIZAR COMPRA + CSV
        // -------------------------
        public bool FinalizarCompra()
        {
            if (_carrito.Count == 0)
                return false;

            // 📁 Ruta a DataFiles/Invoices dentro del proyecto (no en bin)
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Si en tu proyecto la carpeta DataFiles está copiada al output,
            // esta ruta funciona así:
            string folder = Path.Combine(basePath, "DataFiles", "Invoices");

            Directory.CreateDirectory(folder);

            string file = Path.Combine(folder, "registro_compras.csv");

            bool nuevoArchivo = !File.Exists(file);

            using (var sw = new StreamWriter(file, append: true))
            {
                if (nuevoArchivo)
                {
                    sw.WriteLine("Fecha,Usuario,Feria,Producto,Cantidad,PrecioUnitario,TotalLinea");
                }

                string feria = ObtenerFeria()?.MarketName ?? "No Asignada";

                foreach (var item in _carrito)
                {
                    decimal totalLinea = item.producto.Precio * item.cantidad;

                    sw.WriteLine(
                        $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}," +
                        $"{_usuario.Nombre}," +
                        $"{feria}," +
                        $"{item.producto.Nombre}," +
                        $"{item.cantidad}," +
                        $"{item.producto.Precio}," +
                        $"{totalLinea}"
                    );
                }
            }

            // Vaciar carrito luego de registrar
            _carrito.Clear();
            return true;
        }
    }
}


