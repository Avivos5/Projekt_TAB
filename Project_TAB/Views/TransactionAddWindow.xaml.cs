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
        public TransactionAddWindow()
        {
            InitializeComponent();
            DataContext = this;
            NameInput.Text = "elo";
            userAccounts = SqliteDataAccess.getUserAccounts(SqliteLogin.LoggedUserId);
            userCategories = SqliteDataAccess.getUserCategories(SqliteLogin.LoggedUserId);
        }

        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (CategoriesComboBox.SelectedValue == null || AccountsComboBox.SelectedValue == null || TransactionDatePicker.SelectedDate == null || NameInput.Text.Length == 0 || AmountInput.Text.Length == 0)
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
            }
            else
            {
                var newTransaction = new
                {
                    User_Id = SqliteLogin.LoggedUserId,
                    Category_Id = int.Parse(CategoriesComboBox.SelectedValue.ToString()),
                    Account_Id = int.Parse(AccountsComboBox.SelectedValue.ToString()),
                    DateTime = TransactionDatePicker.SelectedDate.Value.ToShortDateString(),
                    Name = NameInput.Text,
                    Transaction_Amount = Convert.ToDouble(AmountInput.Text, provider),
                    Income = IncomeCheckBox.IsChecked == true ? true : false,
                    Current_Amount = 0 // To jest do zmiany!!!!

                };
                SqliteDataAccess.addTransaction(newTransaction);

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
