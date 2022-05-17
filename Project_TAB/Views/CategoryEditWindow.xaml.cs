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
    /// Logika interakcji dla klasy CategoryEditWindow.xaml
    /// </summary>
    public partial class CategoryEditWindow : Window
    {
        public UserCategoryModel editCat { get; set; }

        public CategoryEditWindow(UserCategoryModel category)
        {
            InitializeComponent();
            DataContext = this;

            this.editCat = category;

            NameInput.Text = editCat.Category_Name;
            HiddenCheckBox.IsChecked = editCat.Status ? true : false;
        }

        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {

            if (NameInput.Text.Length == 0)
            {
                MessageBox.Show("Wpisz nazwę.");
            }
            else if (SqliteDataAccess.CheckIfEditCategoryExist(SqliteLogin.LoggedUserId, NameInput.Text, editCat.Id) == true)
            {
                MessageBox.Show("Kategoria o takiej nazwie już istnieje.");
            }
            else
            {
                var updatedCategory = new
                {
                    Id = editCat.Id,
                    Name = NameInput.Text,
                    Status = HiddenCheckBox.IsChecked == true ? true : false,

                };
                SqliteDataAccess.updateCategory(updatedCategory);

                GoBackToCategoriesWindow();
                Close();
            }
        }

        private void GoBackToCategoriesWindow()
        {
            CategoriesWindow categoriesWindow = new CategoriesWindow();
            categoriesWindow.Show();
        }
        private void CategoryEditWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GoBackToCategoriesWindow();
        }

        

    }
}
