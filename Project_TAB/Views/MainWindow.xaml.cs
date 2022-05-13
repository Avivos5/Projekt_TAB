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
        
        public MainWindow()
        {
            InitializeComponent();

            WelcomeLabel.Content = $"Witaj, {SqliteLogin.LoggedUserLogin}";

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
    }
}
