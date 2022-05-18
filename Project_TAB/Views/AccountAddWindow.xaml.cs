using ProjectTabLib;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace Project_TAB.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AccountAddWindow.xaml
    /// </summary>
    public partial class AccountAddWindow : Window
    {
        public AccountAddWindow()
        {
            InitializeComponent();
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (NameInput.Text.Length == 0 || BalanceInput.Text.Length == 0)
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
            }
            else if (SqliteDataAccess.CheckIfAccountExist(SqliteLogin.LoggedUserId, NameInput.Text) == true)
            {
                MessageBox.Show("Takie konto już istnieje.");
            }
            else
            {
                var newAccount = new
                {
                    User_Id = SqliteLogin.LoggedUserId,
                    Name = NameInput.Text,
                    Balance = Convert.ToDouble(BalanceInput.Text, provider),
                    Status = HiddenCheckBox.IsChecked == true ? true : false,
                };
                SqliteDataAccess.addAccount(newAccount);

                GoBackToAccountssWindow();
                Close();
            }
        }

        private void AccountAddWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GoBackToAccountssWindow();
        }

        private void GoBackToAccountssWindow()
        {
            AccountsWindow accountsWindow = new AccountsWindow();
            accountsWindow.Show();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
