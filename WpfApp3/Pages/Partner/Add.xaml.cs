using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        Partners partners;
        Contexts Contexts = new Contexts();
        public static Add add;

        public Add(Partners _partners = null)
        {
            InitializeComponent();
            add = this;
            partners = _partners;
            if (_partners != null)
            {
                nameCompany.Text = _partners.nameCompany;
                address.Text = _partners.address;
                fioDirector.Text = _partners.fioDirector;
                email.Text = _partners.email;
                telephone.Text = _partners.telephone.ToString();
                if (_partners.inn.ToString().Length < 10)
                {
                    int countZero = 10 - _partners.inn.ToString().Count();
                    inn.Text = new string('0', countZero) + _partners.inn.ToString();
                }
                else inn.Text = _partners.inn.ToString();
                rating.Text = _partners.rating.ToString();
            }
            foreach (var item in Contexts.Type_Partner)
            {
                ComboBoxItem itemTypePartner = new ComboBoxItem();
                itemTypePartner.Tag = item.id;
                itemTypePartner.Content = item.name;
                if (_partners != null && _partners.typePartner == item.id) itemTypePartner.IsSelected = true;
                typePartner.Items.Add(itemTypePartner);
            }
        }

        private void addOrChange(object sender, RoutedEventArgs e)
        {
            Regex regexFIO = new Regex(@"^([А-ЯA-Z]|[А-ЯA-Z][\x27а-яa-z]{1,}|[А-ЯA-Z][\x27а-яa-z]{1,}\-([А-ЯA-Z][\x27а-яa-z]{1,}|(оглы)|(кызы)))\040[А-ЯA-Z][\x27а-яa-z]{1,}(\040[А-ЯA-Z][\x27а-яa-z]{1,})?$");
            Regex regexTelephone = new Regex(@"^(?![01234569])((\+7|8)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
            Regex regexINN = new Regex(@"^[0-9]{1,10}$");
            Regex regexRating = new Regex(@"^[0-9]{1,10}$");
            Regex regexEmail = new Regex(@"([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+)");
            if (String.IsNullOrEmpty(nameCompany.Text))
            {
                MessageBox.Show("Введите наименование партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (nameCompany.Text.Length > 100)
            {
                MessageBox.Show("Наименование партнера не может быть настолько большим!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrEmpty(typePartner.Text))
            {
                MessageBox.Show("Выберите тип партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrEmpty(address.Text))
            {
                MessageBox.Show("Введите адрес партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (address.Text.Length > 100)
            {
                MessageBox.Show("Адрес партнера не может быть настолько большим!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrEmpty(fioDirector.Text))
            {
                MessageBox.Show("Введите ФИО директора!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!regexFIO.IsMatch(fioDirector.Text))
            {
                MessageBox.Show("ФИО должно содержать 3 слова и начинаться с большой буквы!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrEmpty(email.Text))
            {
                MessageBox.Show("Введите электронную почту партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!regexEmail.IsMatch(email.Text))
            {
                MessageBox.Show("Неверный формат почты!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrEmpty(telephone.Text))
            {
                MessageBox.Show("Введите номер телефона партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!regexTelephone.IsMatch(telephone.Text))
            {
                MessageBox.Show("Неверный формат номера телефона!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrEmpty(inn.Text))
            {
                MessageBox.Show("ИНН номер партнера не введен или указано отрицательное значение!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!regexINN.IsMatch(inn.Text))
            {
                MessageBox.Show("ИНН состоит из 10 цифр!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrEmpty(rating.Text))
            {
                MessageBox.Show("Рейтинг партнера не введен или указано отрицательное значение!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!regexRating.IsMatch(rating.Text))
            {
                MessageBox.Show("Рейтинг имеет слишком большое значение, содержит буквы или имеет отрицательное значение!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (inn.Text.Length < 10)
            {
                int countZero = 10 - inn.Text.ToString().Count();
                inn.Text = new string('0', countZero) + inn.Text.ToString();
            }
            if (addBtn.Content.ToString() == "Добавить")
            {
                Partners newPartners = new Partners()
                {
                    nameCompany = nameCompany.Text,
                    typePartner = Contexts.Type_Partner.FirstOrDefault(x => x.id == Convert.ToInt64(((ComboBoxItem)typePartner.SelectedItem).Tag)).id,
                    address = address.Text,
                    fioDirector = fioDirector.Text,
                    email = email.Text,
                    telephone = telephone.Text,
                    inn = Convert.ToInt64(inn.Text),
                    rating = Convert.ToInt32(rating.Text)
                };
                Contexts.Partners.Add(newPartners);
                Contexts.SaveChanges();
                MessageBox.Show("Успешно добавлен новый партнер!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (addBtn.Content.ToString() == "Изменить")
            {
                var updatePartner = Contexts.Partners.FirstOrDefault(x => x.id == partners.id);
                if (updatePartner != null)
                {
                    updatePartner.nameCompany = nameCompany.Text;
                    updatePartner.typePartner = Contexts.Type_Partner.FirstOrDefault(x => x.id == Convert.ToInt64(((ComboBoxItem)typePartner.SelectedItem).Tag)).id;
                    updatePartner.address = address.Text;
                    updatePartner.fioDirector = fioDirector.Text;
                    updatePartner.email = email.Text;
                    updatePartner.telephone = telephone.Text;
                    updatePartner.inn = Convert.ToInt64(inn.Text);
                    updatePartner.rating = Convert.ToInt32(rating.Text);
                }
                Contexts.SaveChanges();
                MessageBox.Show("Успешно изменен партнер!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            MainWindow.mainWindow.frame.Navigate(new Main());
        }

        private void backPage(object sender, RoutedEventArgs e) => MainWindow.mainWindow.frame.Navigate(new Main());
    }
}
