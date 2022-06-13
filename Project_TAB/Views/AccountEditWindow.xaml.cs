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
    /// Logika interakcji dla klasy AccountEditWindow.xaml
    /// </summary>
    public partial class AccountEditWindow : Window
    {
        public UserAccountModel editAcc { get; set; }

        public AccountEditWindow(UserAccountModel account)
        {
            InitializeComponent();
            DataContext = this;

            this.editAcc = account;

            NameInput.Text = editAcc.Account_Name;
            HiddenCheckBox.IsChecked = editAcc.Status ? true : false;
        }

        private void EditAccountButton_Click(object sender, RoutedEventArgs e)
        {

            if (NameInput.Text.Length == 0)
            {
                MessageBox.Show("Wpisz nazwę.");
            }
            else if (SqliteDataAccess.CheckIfEditAccountExist(SqliteLogin.LoggedUserId, NameInput.Text, editAcc.Id) == true)
            {
                MessageBox.Show("Kategoria o takiej nazwie już istnieje.");
            }
            else
            {
                var updatedAccount = new
                {
                    Id = editAcc.Id,
                    Name = NameInput.Text,
                    Status = HiddenCheckBox.IsChecked == true ? true : false,

                };
                SqliteDataAccess.updateAccount(updatedAccount);

                Close();
            }
        }

        private void GoBackToAccountssWindow()
        {
            AccountsWindow accountsWindow = new AccountsWindow();
            accountsWindow.Show();
        }

        private void AccountEditWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GoBackToAccountssWindow();
        }

        private void NameInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
