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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        Contexts Contexts = new Contexts();
        public Main()
        {
            InitializeComponent();
            loadItem();
        }

        private void loadItem()
        {
            parent.Children.Clear();
            foreach (var item in Contexts.Partners)
            {
                parent.Children.Add(new Item(item));
            }
        }

        private void addOrChange(object sender, RoutedEventArgs e) => MainWindow.mainWindow.frame.Navigate(new Add());
    }
}


