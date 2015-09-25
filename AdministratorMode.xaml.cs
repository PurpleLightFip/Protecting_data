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
    /// Логика взаимодействия для AdministratorMode.xaml
    /// </summary>
    public partial class AdministratorMode : Window
    {
        public AdministratorMode()
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
            MainWindow mwWindow = new MainWindow();
            mwWindow.Show();
            Close();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddPersonWindow adwWindow = new AddPersonWindow();
            adwWindow.Show();
            Close();
        }

        private void ViewTheList_Click(object sender, RoutedEventArgs e)
        {
            WorkingWithList wlWindow = new WorkingWithList();
            wlWindow.Show();
            Close();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassoword cpWindow = new ChangePassoword();
            cpWindow.Show();
            Close();
        }
    }
}
