using System.Collections.Generic;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Infrastructure.Repositories;
using MercaditoMovil.Views.WinForms.Models;

namespace MercaditoMovil.Views.WinForms.Controllers
{
    /// <summary>
    /// Coordinates cart operations between UI and repositories.
    /// </summary>
    public class CartController
    {
        private readonly ProductAvailabilityRepository _productAvailabilityRepository;
        private readonly MarketRepository _marketRepository;
        private readonly ProducerRepository _producerRepository;

        // Fully qualified to avoid namespace/type conflicts
        private readonly MercaditoMovil.Views.WinForms.InvoiceRepository.InvoiceRepository _invoiceRepository;

        /// <summary>
        /// Initializes controller with required repositories.
        /// </summary>
        public CartController()
        {
            _productAvailabilityRepository = new ProductAvailabilityRepository();
            _marketRepository = new MarketRepository();
            _producerRepository = new ProducerRepository();
            _invoiceRepository = new MercaditoMovil.Views.WinForms.InvoiceRepository.InvoiceRepository();
        }

        /// <summary>
        /// Returns market entity by identifier.
        /// </summary>
        public Market GetMarketById(string marketId)
        {
            return _marketRepository.GetById(marketId);
        }

        /// <summary>
        /// Returns producer entity by identifier.
        /// </summary>
        public Producer GetProducerById(string producerId)
        {
            return _producerRepository.GetById(producerId);
        }

        /// <summary>
        /// Returns all producers available in the system.
        /// </summary>
        public List<Producer> GetAllProducers()
        {
            return _producerRepository.GetAll();
        }

        /// <summary>
        /// Returns all products with current availability.
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return _productAvailabilityRepository.GetAll();
        }

        /// <summary>
        /// Saves an invoice and updates stock for each cart item.
        /// Performs stock validation to avoid negative values.
        /// Returns true when invoice was stored and stock updated.
        /// </summary>
        public bool SaveInvoice(
            User user,
            List<CartItemViewModel> cart,
            string paymentMethod,
            string marketName)
        {
            if (cart == null || cart.Count == 0)
            {
                return false;
            }

            // Validate stock for all items before saving anything.
            for (int i = 0; i < cart.Count; i++)
            {
                CartItemViewModel item = cart[i];

                if (string.IsNullOrWhiteSpace(item.ProductCatalogId) ||
                    string.IsNullOrWhiteSpace(item.ProducerId))
                {
                    // Skip invalid rows.
                    continue;
                }

                int currentStock = _productAvailabilityRepository.GetStock(
                    item.ProducerId,
                    item.ProductCatalogId);

                if (currentStock <= 0)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "El producto " + item.ProductName + " no tiene stock disponible.",
                        "Sin stock",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning);

                    return false;
                }

                if (item.Quantity > currentStock)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "No hay suficiente stock para el producto " + item.ProductName +
                        ". Stock disponible: " + currentStock +
                        ", cantidad solicitada: " + item.Quantity + ".",
                        "Stock insuficiente",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning);

                    return false;
                }
            }

            // Save invoice lines into invoice_records.csv
            bool stored = _invoiceRepository.SaveInvoice(user, cart, paymentMethod, marketName);
            if (!stored)
            {
                // Error already shown by repository.
                return false;
            }

            // Decrease stock in producer_products.csv
            for (int i = 0; i < cart.Count; i++)
            {
                CartItemViewModel item = cart[i];

                if (string.IsNullOrWhiteSpace(item.ProductCatalogId) ||
                    string.IsNullOrWhiteSpace(item.ProducerId))
                {
                    continue;
                }

                _productAvailabilityRepository.DecreaseStock(
                    item.ProducerId,
                    item.ProductCatalogId,
                    item.Quantity);
            }

            return true;
        }
    }
}
