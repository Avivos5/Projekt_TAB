using ProjectTabLib;
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
    /// Logika interakcji dla klasy UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var userLogin = LoginInput.Text;
            var userPassword = PassowordInput.Password.ToString();

            if(SqliteLogin.CheckUserLogin(userLogin, userPassword) == true)
            {
                GrantAccess();
                Close();
            }
            else
            {
                MessageBox.Show("Złe login lub hasło.");
            }

            
        }

        public void GrantAccess()
        {
          
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }


        private void Go_Register_Click(object sender, RoutedEventArgs e)
        {
            UserRegister registerWindow = new UserRegister();
            registerWindow.Show();
            Close();
        }

    }
}
