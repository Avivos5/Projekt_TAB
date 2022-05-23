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
using System.Text.RegularExpressions;
using System.Globalization;

namespace Project_TAB.Views
{
    /// <summary>
    /// Logika interakcji dla klasy TransactionAddWindow.xaml
    /// </summary>
    public partial class TransactionAddWindow : Window
    {
        public List<UserCategoryModel> userCategories { get; set; }
        public List<UserAccountModel> userAccounts { get; set; }

        private Regex amountRgx = new Regex(@"^[0-9]*(\.[0-9]{2})?$");

        public TransactionAddWindow()
        {
            InitializeComponent();
            DataContext = this;

            userAccounts = SqliteDataAccess.getActiveUserAccounts(SqliteLogin.LoggedUserId);
            userCategories = SqliteDataAccess.getActiveUserCategories(SqliteLogin.LoggedUserId);
        }

        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (CategoriesComboBox.SelectedValue == null || AccountsComboBox.SelectedValue == null || TransactionDatePicker.SelectedDate == null || NameInput.Text.Length == 0 || AmountInput.Text.Length == 0)
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
            }
            else if (!amountRgx.IsMatch(AmountInput.Text))
            {
                MessageBox.Show("Zły format kwoty! (Maksymalnie dwa miejsca po kropce).");
            }
            else
            {
                var transaction_Amount = Convert.ToDouble(AmountInput.Text, provider);
                var account_Id = int.Parse(AccountsComboBox.SelectedValue.ToString());
                var income = IncomeCheckBox.IsChecked == true ? true : false;

                var newTransaction = new
                {
                    User_Id = SqliteLogin.LoggedUserId,
                    Category_Id = int.Parse(CategoriesComboBox.SelectedValue.ToString()),
                    Account_Id = account_Id,
                    DateTime = TransactionDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd"),
                    Name = NameInput.Text,
                    Transaction_Amount = transaction_Amount,
                    Income = income,
                    Current_Amount = 0,
                };

                SqliteDataAccess.addTransaction(newTransaction);

                SqliteDataAccess.updateAccountBalance(account_Id, transaction_Amount, income);


                GoBackToMainWindow();
                Close();
            }
        }

        private void TransactionAddWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GoBackToMainWindow();
        }

        private void GoBackToMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
