using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;

namespace MercaditoMovil.Application.Services
{
    /// <summary>
    /// Simple cart service for managing cart items.
    /// </summary>
    public class CartService
    {
        private readonly List<Product> _products = new List<Product>();

        public void AddProduct(Product p)
        {
            _products.Add(p);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
