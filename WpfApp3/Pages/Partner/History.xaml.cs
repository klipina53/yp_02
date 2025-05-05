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

namespace yp02.Pages.Partner
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        Contexts Contexts = new Contexts();

        public History(Int64 id)
        {
            InitializeComponent();
            loadItemHistory(id);
        }

        private void loadItemHistory(Int64 id)
        {
            parent.Children.Clear();
            foreach (var item in Contexts.Partner_Products.Where(x => x.partner == id).ToList())
            {
                parent.Children.Add(new ItemHistory(item));
            }
        }

        private void backPage(object sender, RoutedEventArgs e) => MainWindow.mainWindow.frame.Navigate(new Main());
    }
}

