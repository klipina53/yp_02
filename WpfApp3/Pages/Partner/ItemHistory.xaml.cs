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
            product.Content = Contexts.Products.ToList().Find(x => x.id == partner_Products.product).name;
            partner.Content = Contexts.Partners.ToList().Find(x => x.id == partner_Products.partner).nameCompany;
            countProduct.Content += partner_Products.countProduct.ToString();
            dateSell.Content += partner_Products.dateSell.ToString("dd.MM.yyyy");
        }
    }
}
