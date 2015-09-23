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

namespace FirstLab_DataProtecting
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

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AboutBox abInfo = new AboutBox();
            abInfo.Show();
        }

        private void BackMainWindow_Click(object sender, RoutedEventArgs e)
        {
            AdministratorMode amWindow = new AdministratorMode();
            amWindow.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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
                    Account NewAccount = new Account();
                    NewAccount.bName = Name.Text;
                    NewAccount.bPassword = "";
                    NewAccount.bLock = false;
                    NewAccount.bRestrictionPassword = true;
                    ListOfAccount.account.Add(NewAccount);
                    ListOfAccount.writeFromListToFile();
                    Error.Content = "Логин создан";
                }
            }
        }

        
    }
}
