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

namespace Project_TAB.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserRegister.xaml
    /// </summary>
    public partial class UserRegister : Window
    {
        public UserRegister()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            //UserLogin loginWindow = new UserLogin();
            //loginWindow.Show();
            //Close();
        }

        private void Go_Login_Click(object sender, RoutedEventArgs e)
        {
            UserLogin loginWindow = new UserLogin();
            loginWindow.Show();
            Close();
        }
    }
}
