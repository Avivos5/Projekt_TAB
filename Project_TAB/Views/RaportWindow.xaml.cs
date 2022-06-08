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
using ProjectTabLib;


namespace Project_TAB.Views
{
    /// <summary>
    /// Logika interakcji dla klasy RaportWindow.xaml
    /// </summary>
    public partial class RaportWindow : Window
    {
        List<UserCategoryModel> Categories = new List<UserCategoryModel>();
        List<CategorySelectionRow> CategorySelection = new List<CategorySelectionRow>();
        class CategorySelectionRow {
            public CategorySelectionRow(string s,bool b, UserCategoryModel csr) {
                Category_Name = s;
                Category_Selected = b;
                Category = csr;
            }
            public String Category_Name { get; set; }
            public bool Category_Selected { get; set; }

            public UserCategoryModel Category;
        }

        public RaportWindow()
        {
            InitializeComponent();

            refreshCategoriesTable();
        }
        public void refreshCategoriesTable()
        {
            Categories.AddRange(SqliteDataAccess.getActiveUserCategories(SqliteLogin.LoggedUserId));
            Categories.AddRange(SqliteDataAccess.getInactiveUserCategories(SqliteLogin.LoggedUserId));

            foreach (var v in Categories) {
                CategorySelection.Add(new CategorySelectionRow(v.Category_Name,true,v));
            }
            CategoriesDatagrid.ItemsSource = CategorySelection;
        }

        private void CategoriesDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
           //tu dac jakis popup

        }
    }
}
