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

namespace Project_TAB
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TransactionModel> transactions = new List<TransactionModel>();

        public MainWindow()
        {
            InitializeComponent();

            WelcomeLabel.Content = $"Witaj, {SqliteLogin.LoggedUserLogin}";

            transactions = SqliteDataAccess.LoadTransactions(SqliteLogin.LoggedUserId);
            TransactionsDatagrid.ItemsSource = transactions;
        }
    }
}
