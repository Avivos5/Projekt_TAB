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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_TAB.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TransactionDatagridModel> transactions = new List<TransactionDatagridModel>();

        public List<UserCategoryModel> userCategories { get; set; }
        public List<UserAccountModel> userAccounts { get; set; }

        private double totalBalance { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            userAccounts = SqliteDataAccess.getActiveUserAccounts(SqliteLogin.LoggedUserId);
            userAccounts.Insert(0,new UserAccountModel { Account_Name = "Wszystkie", Balance =0, Id=-1, Status=true, User_id = SqliteLogin.LoggedUserId});
            userCategories = SqliteDataAccess.getActiveUserCategories(SqliteLogin.LoggedUserId);
            userCategories.Insert(0, new UserCategoryModel { Category_Name = "Wszystkie", User_id = SqliteLogin.LoggedUserId, Id = -1, Status = true });
            Accounts_ComboBox.SelectedIndex = 0;
            Categories_ComboBox.SelectedIndex = 0;

            WelcomeLabel.Content = $"Witaj, {SqliteLogin.LoggedUserLogin}";

            totalBalance = SqliteDataAccess.countTotalBalance(SqliteLogin.LoggedUserId);
            TotalBalance.Content = $"Główny Balans: {totalBalance} (zł)";

            refreshTransactionsTable();
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionAddWindow transactionAdd = new TransactionAddWindow();
            transactionAdd.Show();
            Close();
        }


        public void refreshTransactionsTable()
        {
            transactions = SqliteDataAccess.LoadTransactions(SqliteLogin.LoggedUserId);
           
            TransactionsDatagrid.ItemsSource = transactions;

        }


        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            
           int transactionId = ((TransactionDatagridModel)TransactionsDatagrid.SelectedItem).Id;
            MessageBox.Show(SqliteDataAccess.DeleteTransaction(new TransactionDatagridModel() { Id = transactionId }).ToString() + "row affected");
            refreshTransactionsTable();
        }

        private void GoToCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesWindow categoriesWindow = new CategoriesWindow();
            categoriesWindow.Show();
            Close();
        }

        private void GoToAccountsButton_Click(object sender, RoutedEventArgs e)
        {
            AccountsWindow accountsWindow = new AccountsWindow();
            accountsWindow.Show();
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

            int transactionId = ((TransactionDatagridModel)TransactionsDatagrid.SelectedItem).Id;

            TransactionDatagridModel transaction = SqliteDataAccess.SelectTransactionById(transactionId);

            TransactionEditWindow transactionEdit = new TransactionEditWindow(transaction);
            
          
            transactionEdit.Show();

            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (Categories_ComboBox.SelectedIndex == 0 && Accounts_ComboBox.SelectedIndex == 0)
            {
                refreshTransactionsTable();
                return;
            }
            else if (Categories_ComboBox.SelectedIndex != 0 && Accounts_ComboBox.SelectedIndex != 0)
            {
                transactions = SqliteDataAccess.LoadTransactionsByAccountNameAndCategoriesName(Accounts_ComboBox.Text, Categories_ComboBox.Text, SqliteLogin.LoggedUserId);
                
                TransactionsDatagrid.ItemsSource = transactions;
                return;
            }
            else if (Categories_ComboBox.SelectedIndex == 0 && Accounts_ComboBox.SelectedIndex != 0)
            {
               
                transactions = SqliteDataAccess.LoadTransactionsByAccountName(Accounts_ComboBox.Text, SqliteLogin.LoggedUserId);
                TransactionsDatagrid.ItemsSource = transactions;
                return;
            }
            else if (Categories_ComboBox.SelectedIndex != 0 && Accounts_ComboBox.SelectedIndex == 0)
            {
                transactions = SqliteDataAccess.LoadTransactionsByCategorieName(Categories_ComboBox.Text, SqliteLogin.LoggedUserId);
                TransactionsDatagrid.ItemsSource = transactions;
                return;
            }
        }
    }
}
