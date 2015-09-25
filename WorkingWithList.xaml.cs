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
    /// Логика взаимодействия для WorkingWithList.xaml
    /// </summary>
    public partial class WorkingWithList : Window
    {
        int j = 1;

        public WorkingWithList()
        {
            InitializeComponent();
            ListOfAccount.writeFromFileToList();
            Account firstAccount = new Account();
            firstAccount = ListOfAccount.account[j];
            
            personalName.Content = firstAccount.bName;

            if (firstAccount.bLock == true)
            {
                lockPerson.IsChecked = true;
            }
            else
            {
                lockPerson.IsChecked = false;
            }

            if (firstAccount.bRestrictionPassword == true)
            {
                restrictionPassword.IsChecked = true;
            }
            else
            {
                restrictionPassword.IsChecked = false;
            }
            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AboutBox abInfo = new AboutBox();
            abInfo.Show();
        }

        private void BackMainWindow_Click(object sender, RoutedEventArgs e)
        {
            ListOfAccount.writeFromListToFile();
            AdministratorMode admWindow = new AdministratorMode();
            admWindow.Show();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ListOfAccount.writeFromListToFile();
            Close();
        }

        private void SaveInfoPerson_Click(object sender, RoutedEventArgs e)
        {
            Account firstAccount = new Account();
            firstAccount = ListOfAccount.account[j];

            if (lockPerson.IsChecked == true)
            {
                firstAccount.bLock = true;
            }
            else
            {
                firstAccount.bLock = false;
            }

            if (restrictionPassword.IsChecked == true)
            {
                firstAccount.bRestrictionPassword = true;
            }
            else
            {
                firstAccount.bRestrictionPassword = false;
            }

            ListOfAccount.account[j] = firstAccount;

        }

        private void PreviousPersonClick(object sender, RoutedEventArgs e)
        {


            if (j != 1)
            {
                j--;
            }
            else
            {
                j = ListOfAccount.Count() - 1;
            }

            Account firstAccount = new Account();
            firstAccount = ListOfAccount.account[j];

            personalName.Content = firstAccount.bName;

            if (firstAccount.bLock == true)
            {
                lockPerson.IsChecked = true;
            }
            else
            {
                lockPerson.IsChecked = false;
            }

            if (firstAccount.bRestrictionPassword == true)
            {
                restrictionPassword.IsChecked = true;
            }
            else
            {
                restrictionPassword.IsChecked = false;
            }
        }

        private void NextPersonClick(object sender, RoutedEventArgs e)
        {
            
            if (j != ListOfAccount.Count() - 1)
            {
                j++;
            }
            else
            {
                j = 1;
            }

            Account firstAccount = new Account();
            firstAccount = ListOfAccount.account[j];

            personalName.Content = firstAccount.bName;

            if (firstAccount.bLock == true)
            {
                lockPerson.IsChecked = true;
            }
            else
            {
                lockPerson.IsChecked = false;
            }

            if (firstAccount.bRestrictionPassword == true)
            {
                restrictionPassword.IsChecked = true;
            }
            else
            {
                restrictionPassword.IsChecked = false;
            }
        }
    }
}
