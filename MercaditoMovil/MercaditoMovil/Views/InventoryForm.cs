using MercaditoMovil.Domain.Entities;
using MercaditoMovil.Views.WinForms.Controllers;

namespace MercaditoMovil.Views.WinForms
{
    /// <summary>
    /// Inventory visualization form.
    /// </summary>
    public partial class InventoryForm : Form
    {
        private readonly CartController _controller = new CartController();

        public InventoryForm()
        {
            InitializeComponent();
            LoadInventory();
        }

        /// <summary>
        /// Loads product list and shows stock information.
        /// </summary>
        private void LoadInventory()
        {
            LvInventory.Items.Clear();

            List<Product> products = _controller.GetAllProducts();

            for (int i = 0; i < products.Count; i++)
            {
                Product p = products[i];

                ListViewItem item = new ListViewItem(p.ProductCatalogId);
                item.SubItems.Add(p.Name);
                item.SubItems.Add(p.ProducerId);
                item.SubItems.Add(p.Unit);
                item.SubItems.Add(p.Packaging);
                item.SubItems.Add("₡" + p.Price);
                item.SubItems.Add(p.Stock.ToString());

                LvInventory.Items.Add(item);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }
    }
}
