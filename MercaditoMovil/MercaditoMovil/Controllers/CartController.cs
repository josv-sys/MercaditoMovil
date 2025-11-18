using System.Collections.Generic;
using MercaditoMovil.Application.Services;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Views.WinForms.Controllers
{
    /// <summary>
    /// Controller que coordina la vista del carrito con el servicio de carrito.
    /// </summary>
    public class CartController
    {
        private readonly CartService _cartService;

        public User CurrentUser { get; }

        public CartController(User user)
        {
            CurrentUser = user;
            _cartService = new CartService(user);
        }

        public Market? GetMarket()
        {
            return _cartService.ObtenerFeria();
        }

        public List<Product> GetProducts()
        {
            return _cartService.ObtenerProductos();
        }

        /// <summary>
        /// Devuelve la lista cruda de items del carrito.
        /// </summary>
        public List<(Product product, int quantity)> GetCartItemsRaw()
        {
            return _cartService.ObtenerCarrito();
        }

        public void AddItem(Product product, int quantity)
        {
            _cartService.Agregar(product, quantity);
        }

        /// <summary>
        /// Quita un item del carrito por indice.
        /// </summary>
        public void RemoveItemAt(int index)
        {
            var items = _cartService.ObtenerCarrito();
            if (index < 0 || index >= items.Count)
            {
                return;
            }

            _cartService.Quitar(items[index]);
        }

        public bool Checkout()
        {
            return _cartService.FinalizarCompra();
        }

        public string GetUserFullName()
        {
            string f = CurrentUser.FirstName ?? string.Empty;
            string l1 = CurrentUser.LastName1 ?? string.Empty;
            string l2 = CurrentUser.LastName2 ?? string.Empty;

            return (f + " " + l1 + " " + l2).Trim();
        }
    }
}

