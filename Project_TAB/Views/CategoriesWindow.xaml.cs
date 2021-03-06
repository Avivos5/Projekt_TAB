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
    /// Logika interakcji dla klasy CategoriesWindow.xaml
    /// </summary>
    public partial class CategoriesWindow : Window
    {

        List<UserCategoryModel> activeCategories = new List<UserCategoryModel>();
        List<UserCategoryModel> inactiveCategories = new List<UserCategoryModel>();

        public CategoriesWindow()
        {
            InitializeComponent();

            refreshCategoriesTable();
        }


        public void refreshCategoriesTable()
        {
            activeCategories = SqliteDataAccess.getActiveUserCategories(SqliteLogin.LoggedUserId);
            inactiveCategories = SqliteDataAccess.getInactiveUserCategories(SqliteLogin.LoggedUserId);

            CategoriesDatagrid.ItemsSource = activeCategories;
            InactiveCategoriesDatagrid.ItemsSource = inactiveCategories;

        }

        private void AddCategorieButton_Click(object sender, RoutedEventArgs e)
        {
            CategorieAddWindow categorieAdd = new CategorieAddWindow();
            categorieAdd.Show();
            Close();

        }

        private void GoToCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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

            int categorieId = ((UserCategoryModel)CategoriesDatagrid.SelectedItem).Id;

            UserCategoryModel category = SqliteDataAccess.SelectCategorieById(categorieId);

            CategoryEditWindow categoryEdit = new CategoryEditWindow(category);


            categoryEdit.Show();

            Close();
        }

        private void EditInactive_Click(object sender, RoutedEventArgs e)
        {

            int categorieId = ((UserCategoryModel)InactiveCategoriesDatagrid.SelectedItem).Id;

            UserCategoryModel category = SqliteDataAccess.SelectCategorieById(categorieId);

            CategoryEditWindow categoryEdit = new CategoryEditWindow(category);


            categoryEdit.Show();

            Close();
        }

        private void CategoriesDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
