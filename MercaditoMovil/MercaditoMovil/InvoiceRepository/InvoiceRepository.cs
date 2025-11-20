using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Views.WinForms.Models;

namespace MercaditoMovil.Views.WinForms.InvoiceRepository
{
    /// <summary>
    /// Handles invoice persistence in invoice_records.csv.
    /// </summary>
    public class InvoiceRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes repository and ensures CSV file exists.
        /// </summary>
        public InvoiceRepository()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            _filePath = Path.Combine(
                baseDir,
                "DataFiles",
                "Invoices",
                "invoice_records.csv");

            EnsureFileExists();
        }

        /// <summary>
        /// Creates invoice file with header if it does not exist.
        /// </summary>
        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                string header =
                    "InvoiceId,UserId,UserName,MarketId,MarketName," +
                    "ProducerId,ProductCatalogId,ProductName,Quantity," +
                    "UnitPrice,TotalPrice,PaymentMethod,InvoiceDateTime";

                Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
                File.WriteAllText(_filePath, header + Environment.NewLine, Encoding.UTF8);
            }
        }

        /// <summary>
        /// Saves a complete invoice for the given user and cart.
        /// Each cart item becomes one line in invoice_records.csv.
        /// Returns true when append operation was successful.
        /// </summary>
        public bool SaveInvoice(
            User user,
            List<CartItemViewModel> cart,
            string paymentMethod,
            string marketName)
        {
            if (user == null || cart == null || cart.Count == 0)
            {
                return false;
            }

            const decimal salesTaxRate = 0.13m;   // Costa Rica VAT
            const decimal serviceFeeRate = 0.02m; // App service fee

            string invoiceId = Guid.NewGuid().ToString("N").Substring(0, 12);
            string safeMarketName = Safe(marketName ?? "Unknown");

            var lines = new List<string>();

            for (int i = 0; i < cart.Count; i++)
            {
                CartItemViewModel item = cart[i];

                decimal baseAmount = item.UnitPrice * item.Quantity;
                decimal taxAmount = baseAmount * salesTaxRate;
                decimal serviceAmount = baseAmount * serviceFeeRate;
                decimal totalWithTaxes = baseAmount + taxAmount + serviceAmount;

                string csvLine =
                    invoiceId + "," +
                    user.UserId + "," +
                    Safe(user.FirstName + " " + user.LastName1 + " " + user.LastName2) + "," +
                    user.MarketId + "," +
                    safeMarketName + "," +
                    item.ProducerId + "," +
                    item.ProductCatalogId + "," +
                    Safe(item.ProductName) + "," +
                    item.Quantity + "," +
                    item.UnitPrice.ToString(CultureInfo.InvariantCulture) + "," +
                    totalWithTaxes.ToString(CultureInfo.InvariantCulture) + "," +
                    paymentMethod + "," +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lines.Add(csvLine);
            }

            try
            {
                File.AppendAllLines(_filePath, lines, Encoding.UTF8);
                return true;
            }
            catch (IOException)
            {
                MessageBox.Show(
                    "No se pudo guardar la factura porque el archivo invoice_records.csv " +
                    "esta siendo usado por otro programa (por ejemplo Excel). " +
                    "Cierre el archivo y vuelva a intentar.",
                    "Error al guardar la factura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        /// <summary>
        /// Sanitizes strings for CSV output (removes commas and trims).
        /// </summary>
        private string Safe(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            return value.Replace(",", ";").Trim();
        }
    }
}
