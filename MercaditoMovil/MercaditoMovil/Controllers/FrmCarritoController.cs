using System.Collections.Generic;
using MercaditoMovil.Application.Services;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Views.WinForms.Controllers
{
    public class FrmCarritoController
    {
        private readonly CarritoService _carritoService;

        public Usuario Usuario { get; }

        public FrmCarritoController(Usuario usuario)
        {
            Usuario = usuario;
            _carritoService = new CarritoService(usuario);
        }

        public Feria? ObtenerFeria()
            => _carritoService.ObtenerFeria();

        public List<Producto> ObtenerProductos()
            => _carritoService.ObtenerProductos();

        public List<(Producto producto, int cantidad)> ObtenerCarrito()
            => _carritoService.ObtenerCarrito();

        public void Agregar(Producto producto, int cantidad)
            => _carritoService.Agregar(producto, cantidad);

        public void Quitar((Producto producto, int cantidad) item)
            => _carritoService.Quitar(item);

        public bool FinalizarCompra()
            => _carritoService.FinalizarCompra();
    }
}





