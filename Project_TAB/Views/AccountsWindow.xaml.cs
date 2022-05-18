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
    /// Logika interakcji dla klasy AccountsWindows.xaml
    /// </summary>
    public partial class AccountsWindow : Window
    {

        List<UserAccountModel> accounts = new List<UserAccountModel>();


        public AccountsWindow()
        {
            InitializeComponent();

            refreshAccountsTable();
        }

        public void refreshAccountsTable()
        {
            accounts = SqliteDataAccess.getUserAccounts(SqliteLogin.LoggedUserId);

            AccountsDatagrid.ItemsSource = accounts;

        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountAddWindow accountAdd = new AccountAddWindow();
            accountAdd.Show();
            Close();
        }

        private void GoToCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            SqliteLogin.LoggedUserId = 0;
            SqliteLogin.LoggedUserLogin = null;
            UserLogin loginWindow = new UserLogin();
            loginWindow.Show();
            Close();
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            int accountId = ((UserAccountModel)AccountsDatagrid.SelectedItem).Id;

            UserAccountModel account = SqliteDataAccess.SelectAccountById(accountId);

            AccountEditWindow accountEdit = new AccountEditWindow(account);


            accountEdit.Show();

            Close();
        }

    }
}
