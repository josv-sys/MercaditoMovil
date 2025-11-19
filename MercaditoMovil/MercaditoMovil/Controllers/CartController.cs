using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Infrastructure.Repositories;
using MercaditoMovil.Views.WinForms.Models;
using MercaditoMovil.Views.WinForms.Repositories;


namespace MercaditoMovil.Views.WinForms.Controllers
{
    /// <summary>
    /// Coordinates cart operations with repositories.
    /// </summary>
    public class CartController
    {
        private readonly ProductAvailabilityRepository _productRepo = new ProductAvailabilityRepository();
        private readonly ProducerRepository _producerRepo = new ProducerRepository();
        private readonly MarketRepository _marketRepo = new MarketRepository();
        private readonly InvoiceRepository _invoiceRepo = new InvoiceRepository();

        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAll();
        }

        public List<Producer> GetAllProducers()
        {
            return _producerRepo.GetAll();
        }

        public Producer GetProducerById(string id)
        {
            return _producerRepo.GetById(id);
        }

        public Market GetMarketById(string id)
        {
            return _marketRepo.GetById(id);
        }

        public void SaveInvoice(User user, List<CartItemViewModel> cart, string payment)
        {
            _invoiceRepo.SaveInvoice(user, cart, payment);
        }
    }
}
