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
using System.Windows.Shapes;

namespace DataProtecting
{
    /// <summary>
    /// Логика взаимодействия для AddPersonWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {
        public AddPersonWindow()
        {
            InitializeComponent();
        }

        private void MenuItemClick(object sender, RoutedEventArgs e)
        {
            AboutBox abInfo = new AboutBox();
            abInfo.Show();
        }

        private void BackMainWindowClick(object sender, RoutedEventArgs e)
        {
            AdministratorMode amWindow = new AdministratorMode();
            amWindow.Show();
            Close();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                Error.Content = "Заполните все поля";
            }
            else
            {
                if (ListOfAccount.Search(Name.Text))
                {
                    Error.Content = "Имя уже используется";
                }
                else
                {
                    Account newAccount = new Account();
                    newAccount.bName = Name.Text;
                    newAccount.bPassword = "";
                    newAccount.bLock = false;
                    newAccount.bRestrictionPassword = true;
                    ListOfAccount.account.Add(newAccount);
                    ListOfAccount.writeFromListToFile();
                    Error.Content = "Логин создан";
                }
            }
        }

        
    }
}
