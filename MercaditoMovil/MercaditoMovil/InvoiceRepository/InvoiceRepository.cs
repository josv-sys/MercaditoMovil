using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Infrastructure.Repositories;
using MercaditoMovil.Views.WinForms.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MercaditoMovil.Views.WinForms.Repositories
{
    /// <summary>
    /// Saves invoice records into invoice_records.csv.
    /// Lives in WinForms layer because it uses view models.
    /// </summary>
    public class InvoiceRepository
    {
        private readonly string _filePath;

        public InvoiceRepository()
        {
            _filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DataFiles",
                "Invoices",
                "invoice_records.csv");

            EnsureFileExists();
        }

        /// <summary>
        /// Creates CSV file if missing.
        /// </summary>
        private void EnsureFileExists()
        {
            string dir = Path.GetDirectoryName(_filePath);
            Directory.CreateDirectory(dir);

            if (!File.Exists(_filePath))
            {
                string header =
                    "InvoiceId,Date,UserId,UserName,PaymentMethod," +
                    "ProductName,Unit,Packaging,UnitPrice,Quantity,Amount";

                File.WriteAllText(_filePath, header + Environment.NewLine, Encoding.UTF8);
            }
        }

        /// <summary>
        /// Saves invoice lines into CSV.
        /// </summary>
        public void SaveInvoice(User user, List<CartItemViewModel> cart, string paymentMethod)
        {
            string invoiceId = Guid.NewGuid().ToString();
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var products = new ProductAvailabilityRepository().GetAll();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < cart.Count; i++)
            {
                CartItemViewModel item = cart[i];
                Product p = FindProduct(products, item.ProductName);

                string line =
                    invoiceId + "," +
                    date + "," +
                    user.UserId + "," +
                    user.FirstName + " " + user.LastName1 + " " + user.LastName2 + "," +
                    paymentMethod + "," +
                    item.ProductName + "," +
                    p.Unit + "," +
                    p.Packaging + "," +
                    p.Price + "," +
                    item.Quantity + "," +
                    item.Total;

                sb.AppendLine(line);
            }

            File.AppendAllText(_filePath, sb.ToString(), Encoding.UTF8);
        }

        private Product FindProduct(List<Product> list, string name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == name)
                    return list[i];
            }
            return null;
        }
    }
}
