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
using System.IO;

namespace DataProtecting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int j = 0;

        public MainWindow()
        {
            ListOfAccount.account = new List<Account>();
            ListOfAccount.CreateFile();
            ListOfAccount.writeFromFileToList();
            InitializeComponent();
        }

        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AboutBox abInfo = new AboutBox();
            abInfo.Show();
        }

        private void ButtonClick2(object sender, RoutedEventArgs e)
        {
            ListOfAccount.strLogin = "";
            Account newAccount = new Account();
            newAccount = ListOfAccount.account[0];

            if (Name.Text == "")
            {
                Message.Content = "Введите имя";
            }
            else
            {
                if (Password.Password == newAccount.bPassword && Name.Text == "ADMIN")
                {
                    ListOfAccount.strLogin = Name.Text;
                    ChangePassoword chWindow = new ChangePassoword();
                    chWindow.Show();
                    Close();        
                }
                else 
                {    
                    int iCheck = ListOfAccount.Authorization(Name.Text, Password.Password);

                    if (iCheck == 1)
                    {
                        if (ListOfAccount.strLogin == "ADMIN")
                        {
                                AdministratorMode amWindow = new AdministratorMode();
                                amWindow.Show();
                                Close();
                        }
                        else
                        {
                            ChangePassoword chWindow = new ChangePassoword();
                            chWindow.Show();
                            Close();
                        }
                    }

                    if (iCheck == 2)
                    {
                        Message.Content = "Логин заблокирован";
                    }

                    if (iCheck == 0)
                    {
                        if (j < 2)
                        {
                            Message.Content = "Не существует имени c таким паролем";
                            j++;
                        }
                        else
                        {
                            Close();
                        }
                    }
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
