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
    /// Логика взаимодействия для ChangePassoword.xaml
    /// </summary>
    public partial class ChangePassoword : Window
    {
        public ChangePassoword()
        {
            InitializeComponent();
        }

        private void BackMainWindow_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfAccount.strLogin == "ADMIN" && ListOfAccount.bCheakAdmin == true)
            {
                AdministratorMode amWindow = new AdministratorMode();
                amWindow.Show();
                Close();
            }
            else
            {
                MainWindow mnWindow = new MainWindow();
                mnWindow.Show();
                Close();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AboutBox abInfo = new AboutBox();
            abInfo.Show();
        }

        private void ConfPassword_Click(object sender, RoutedEventArgs e)
        {
            Error.Content = "";
            Error2.Content = "";
            int j = 0;
            bool bCheck = false;
            string strPassword = "";
            ListOfAccount.bCheakAdmin = false;
            for (int i = 0; i < ListOfAccount.account.Count; i++)
            {
                Account checkAccount = new Account();
                checkAccount = ListOfAccount.account[i];
                if (checkAccount.bName == ListOfAccount.strLogin)
                {
                    j = i;
                    bCheck = checkAccount.bRestrictionPassword;
                    strPassword = checkAccount.bPassword;
                }
            }

            if (NewPassword.Password == "" || ConfNewPassword.Password == "")
                {
                    Error.Content = "Заполните все поля";
                }
                else
                {
                    if (NewPassword.Password == ConfNewPassword.Password
                        && OldPassword.Password == strPassword)
                    {
                        if (bCheck == true)
                        {

                            if (ListOfAccount.Restriction(NewPassword.Password))
                            {
                                Account NewAccount = new Account();
                                NewAccount.bName = ListOfAccount.strLogin;
                                NewAccount.bPassword = NewPassword.Password;
                                NewAccount.bLock = false;
                                NewAccount.bRestrictionPassword = bCheck;
                                ListOfAccount.account[j] = NewAccount;
                                ListOfAccount.writeFromListToFile();
                                Error.Content = "Пароль успешно заменен";
                                ListOfAccount.bCheakAdmin = true;
                            }
                            else
                            {
                                Error.Content = "Пароль имеет недопустимые";
                                Error2.Content = "символы";
                            }
                        }
                        else
                        {
                            Account NewAccount = new Account();
                            NewAccount.bName = ListOfAccount.strLogin;
                            NewAccount.bPassword = NewPassword.Password;
                            NewAccount.bLock = false;
                            NewAccount.bRestrictionPassword = bCheck;
                            ListOfAccount.account[j] = NewAccount;
                            ListOfAccount.writeFromListToFile();
                            Error.Content = "Пароль успешно заменен";
                            ListOfAccount.bCheakAdmin = true;
                        }
                    }
                    else Error.Content = "Проверьте правильность старого пароля";
                }
        }
    }
}
