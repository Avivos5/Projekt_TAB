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
    /// Logika interakcji dla klasy CategorieAddWindow.xaml
    /// </summary>
    public partial class CategorieAddWindow : Window
    {
        public CategorieAddWindow()
        {
            InitializeComponent();
        }

        private void AddCategorieButton_Click(object sender, RoutedEventArgs e)
        {

            if (NameInput.Text.Length == 0 )
            {
                MessageBox.Show("Wpisz nazwę.");
            }
            else if (SqliteDataAccess.CheckIfCategoryExist(SqliteLogin.LoggedUserId, NameInput.Text) == true)
            {
                MessageBox.Show("Taka kategoria już istnieje.");
            }
            else
            {
                var newCategorie = new
                {
                    User_Id = SqliteLogin.LoggedUserId,
                    Name = NameInput.Text,
                    Status = HiddenCheckBox.IsChecked == true ? true : false,
                };
                SqliteDataAccess.addCategorie(newCategorie);

                Close();
            }
        }

        private void CategorieAddWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GoBackToCategoriesWindow();
        }

        private void GoBackToCategoriesWindow()
        {
            CategoriesWindow categoriesWindow = new CategoriesWindow();
            categoriesWindow.Show();
        }



    }
}
