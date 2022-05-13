using ProjectTabLib;
using System;
using System.Collections.Generic;
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
        public TransactionEditWindow()
        {
            InitializeComponent();
          
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

        }

        private void NameInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
