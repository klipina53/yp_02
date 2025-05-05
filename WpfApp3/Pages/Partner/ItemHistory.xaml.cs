using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using yp02.Classes.Context;
using yp02.Classes;
using System.Diagnostics;

namespace yp02.Pages.Partner
{
    /// <summary>
    /// Логика взаимодействия для ItemHistory.xaml
    /// </summary>
    public partial class ItemHistory : UserControl
    {
        Contexts Contexts = new Contexts();

        public ItemHistory(Partner_Products partner_Products)
        {
            InitializeComponent();

            var productItem = Contexts.Products.ToList().FirstOrDefault(x => x.id == partner_Products.product);

            // Logging the retrieved product name type and value
            Debug.WriteLine($"Retrieved Product Name Type: {productItem?.name?.GetType().ToString()} Value: {productItem?.name}");

            if (productItem != null)
            {
                product.Content = productItem.name ?? "Name Not Found"; // Handle null or invalid names
            }
            else
            {
                product.Content = "Product Not Found";
            }

            var partnerItem = Contexts.Partners.ToList().FirstOrDefault(x => x.id == partner_Products.partner);
            partner.Content = partnerItem != null ? partnerItem.nameCompany : "Partner Not Found";

            countProduct.Content += partner_Products.countProduct.ToString();
            dateSell.Content += partner_Products.dateSell.ToString("dd.MM.yyyy");
        }


    }
}
