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
using Microsoft.EntityFrameworkCore;

namespace yp02.Pages.Partner
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        Contexts Contexts = new Contexts();
        Partners partners;
        public Item(Partners _partners)
        {
            InitializeComponent();
            partners = _partners;
            typeAndName.Content = Contexts.Type_Partner.ToList().Find(x => x.id == _partners.typePartner).name + " | " + _partners.nameCompany;
            discount.Content = GetDiscount(_partners.id) + "%";
            director.Content = _partners.fioDirector;
            telephone.Content = _partners.telephone;
            rating.Content = "Рейтинг: " + _partners.rating;
        }

        public Int64 GetDiscount(Int64 id)
        {
            var discount = Contexts.GetChanges.FromSqlRaw("CALL GetChanges({0})", id).ToList();

            double totalProducts = discount.Sum(x => x.countProduct);

            if (totalProducts < 10000) return 0;
            else if (totalProducts >= 10000 && totalProducts < 50000) return 5;
            else if (totalProducts >= 50000 && totalProducts < 300000) return 10;
            else return 15;
        }

        private void updatePartner(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Add(partners));
            Add.add.header.Content = "Изменение партнера";
            Add.add.addBtn.Content = "Изменить";
        }

        private void historyProduct(object sender, System.Windows.RoutedEventArgs e) => MainWindow.mainWindow.frame.Navigate(new History(partners.id));
    }
}
