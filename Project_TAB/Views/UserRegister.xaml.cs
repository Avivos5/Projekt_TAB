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
            var userLogin = LoginInput.Text;
            var userPassword = PassowordInput.Password.ToString();
            var userPasswordRepeated = RepeatPassowordInput.Password.ToString();

            if(userLogin.Length == 0 || userPassword.Length == 0 || userPasswordRepeated.Length == 0)
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
            }
            else if (!userPassword.Equals(userPasswordRepeated))
            {
                MessageBox.Show("Hasła nie są takie same.");
            }
            else if (SqliteRegistration.CheckIfExist(userLogin) == true)
            {
                MessageBox.Show("Taki użytkownik już istnieje.");
            }
            else
            {
                if(SqliteRegistration.RegisterUser(userLogin, userPassword) > 0)
                {
                    GoToLoginPage();
                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak.");
                }
            }

        }

        private void Go_Login_Click(object sender, RoutedEventArgs e)
        {
            GoToLoginPage();
        }

        private void GoToLoginPage()
        {
            UserLogin loginWindow = new UserLogin();
            loginWindow.Show();
            Close();
        }
    }
}
