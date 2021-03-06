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

            WelcomeLabel.Content = $"{SqliteLogin.LoggedUserLogin}";

            refreshTransactionsTable();
            refreshTotalBalance();
            
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
        
        public void refreshTotalBalance()
        {
            totalBalance = SqliteDataAccess.countTotalBalance(SqliteLogin.LoggedUserId);
            TotalBalance.Content = $"Główny Balans: {Math.Round(totalBalance, 2)} (zł)";
        }

        


        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            int transactionId = ((TransactionDatagridModel)TransactionsDatagrid.SelectedItem).Id;
            double transactionAmount = ((TransactionDatagridModel)TransactionsDatagrid.SelectedItem).Transaction_Amount;
            int transactionAccountId = ((TransactionDatagridModel)TransactionsDatagrid.SelectedItem).Account_Id;
            bool transactionIsIncome = ((TransactionDatagridModel)TransactionsDatagrid.SelectedItem).Income;

            if (MessageBox.Show("Czy na pewno usunąć transakcję?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                SqliteDataAccess.DeleteTransaction(transactionId);
                SqliteDataAccess.updateAccountBalanceonDelete(transactionAccountId, transactionAmount, transactionIsIncome);
                refreshTransactionsTable();
                refreshTotalBalance();
            }

            
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

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker1.SelectedDate == null && datePicker2.SelectedDate == null && Categories_ComboBox.SelectedIndex == 0 && Accounts_ComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
                return;
            }
            else if (Categories_ComboBox.SelectedIndex != 0 && Accounts_ComboBox.SelectedIndex != 0 && datePicker1.SelectedDate == null && datePicker2.SelectedDate == null)
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

            else if (datePicker1.SelectedDate != null && datePicker2.SelectedDate != null && Categories_ComboBox.SelectedIndex != 0 && Accounts_ComboBox.SelectedIndex == 0)
            {
                transactions = SqliteDataAccess.LoadTransactionsByDateToDateAndCategories(datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"), SqliteLogin.LoggedUserId, Categories_ComboBox.Text);
                TransactionsDatagrid.ItemsSource = transactions;
            }
            else if (Categories_ComboBox.SelectedIndex != 0 && Accounts_ComboBox.SelectedIndex == 0)
            {
                transactions = SqliteDataAccess.LoadTransactionsByCategorieName(Categories_ComboBox.Text, SqliteLogin.LoggedUserId);
                TransactionsDatagrid.ItemsSource = transactions;
                return;
            }
            else if (datePicker1.SelectedDate == null && datePicker2.SelectedDate != null && Categories_ComboBox.SelectedIndex == 0 && Accounts_ComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Wybierz date Od:");
                return;
            }
            else if (datePicker1.SelectedDate != null && datePicker2.SelectedDate != null && Categories_ComboBox.SelectedIndex == 0 && Accounts_ComboBox.SelectedIndex == 0)
            {
                transactions = SqliteDataAccess.LoadTransactionsByDateToDate(datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"), SqliteLogin.LoggedUserId);
                TransactionsDatagrid.ItemsSource = transactions;
                return;
            }

            else if (datePicker1.SelectedDate != null && datePicker2.SelectedDate != null && Categories_ComboBox.SelectedIndex != 0 && Accounts_ComboBox.SelectedIndex != 0)
            {
                transactions = SqliteDataAccess.LoadTransactionsByDateToDateAndCategoriesAndAccounts(datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"), SqliteLogin.LoggedUserId, Categories_ComboBox.Text, Accounts_ComboBox.Text);
                TransactionsDatagrid.ItemsSource = transactions;
                return;
            }
            else if (datePicker1.SelectedDate != null && datePicker2.SelectedDate != null && Categories_ComboBox.SelectedIndex != 0 && Accounts_ComboBox.SelectedIndex != 0)
            {
                transactions = SqliteDataAccess.LoadTransactionsByDateToDateAndCategoriesAndAccounts(datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"), SqliteLogin.LoggedUserId, Categories_ComboBox.Text, Accounts_ComboBox.Text);
                TransactionsDatagrid.ItemsSource = transactions;
                return;
            }
        }

        private void ResetFilterButton_Click(object sender, RoutedEventArgs e)
        {
            datePicker1.SelectedDate = null;
            datePicker2.SelectedDate = null;
            Categories_ComboBox.SelectedIndex = 0;
            Accounts_ComboBox.SelectedIndex = 0;



            refreshTransactionsTable();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GoToRaport(object sender, RoutedEventArgs e)
        {
            RaportWindow raportwindow = new RaportWindow();
            raportwindow.Show();
            Close();
        }
    }
}
