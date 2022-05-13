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
    /// Logika interakcji dla klasy TransactionEditWindow.xaml
    /// </summary>
    public partial class TransactionEditWindow : Window
    {
        public List<UserCategoryModel> userCategories { get; set; }
        public List<UserAccountModel> userAccounts { get; set; }
        public TransactionDatagridModel editTrans { get; set; }

        //public TransactionEditWindow()
        //{
        //    InitializeComponent();
          
        //}

        public TransactionEditWindow(TransactionDatagridModel transaction)
        {
            InitializeComponent();
            DataContext = this;

            userAccounts = SqliteDataAccess.getUserAccounts(SqliteLogin.LoggedUserId);
            userCategories = SqliteDataAccess.getUserCategories(SqliteLogin.LoggedUserId);

            this.editTrans = transaction;

            NameInput.Text = transaction.Name;
            AmountInput.Text = transaction.Transaction_Amount.ToString();
            TransactionDatePicker.SelectedDate = DateTime.Parse(transaction.DateTime);
            AccountsComboBox.SelectedValue = transaction.Account_Id;
            CategoriesComboBox.SelectedValue = transaction.Category_Id;
            IncomeCheckBox.IsChecked = transaction.Income ? true : false;
        }


        private void GoBackToMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void TransactionEditWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GoBackToMainWindow();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void EditTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            if (CategoriesComboBox.SelectedValue == null || AccountsComboBox.SelectedValue == null || TransactionDatePicker.SelectedDate == null || NameInput.Text.Length == 0 || AmountInput.Text.Length == 0)
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
            }
            else
            {
                var updatedTransaction = new
                {
                    Id = editTrans.Id,
                    Category_Id = int.Parse(CategoriesComboBox.SelectedValue.ToString()),
                    Account_Id = int.Parse(AccountsComboBox.SelectedValue.ToString()),
                    DateTime = TransactionDatePicker.SelectedDate.Value.ToShortDateString(),
                    Name = NameInput.Text,
                    Transaction_Amount = Convert.ToDouble(AmountInput.Text, provider),
                    Income = IncomeCheckBox.IsChecked == true ? true : false,
                    Current_Amount = 0 // To jest do zmiany!!!!

                };
                SqliteDataAccess.updateTransaction(updatedTransaction);

                GoBackToMainWindow();
                Close();
            }
        }
    }
}
