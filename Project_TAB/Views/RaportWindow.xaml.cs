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
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using ProjectTabLib;
using System.IO;
using Microsoft.Win32;
using System.Collections;

namespace Project_TAB.Views
{
    /// <summary>
    /// Logika interakcji dla klasy RaportWindow.xaml
    /// </summary>
    public partial class RaportWindow : Window
    {
        public List<CategorySelectionRow> CategorySelection = new List<CategorySelectionRow>();
        public List<AccountSelectionRow> AccountSelection = new List<AccountSelectionRow>();
        //List<UserAccountModel> Accounts = new List<UserAccountModel>();
        public List<UserAccountModel> userAccounts { get; set; }
        List<UserCategoryModel> Categories = new List<UserCategoryModel>();


        public class CategorySelectionRow {
            public CategorySelectionRow(string s,bool b, UserCategoryModel csr) {
                Category_Name = s;
                Category_Selected = b;
                Category = csr;
            }
            public String Category_Name { get; set; }
            public bool Category_Selected { get; set; }

            public UserCategoryModel Category;
        }

        public class AccountSelectionRow {
            public AccountSelectionRow(string s, bool b, UserAccountModel acs)
            {
                Account_Name = s;
                Account_Selected = b;
                Account = acs;
            }
            public String Account_Name { get; set; }
            public bool Account_Selected { get; set; }
            public UserAccountModel Account;
        }
        public struct catrow
        {
            public string catname;
            public double loss;
            public double gain;
        };

        public RaportWindow()
        {
            InitializeComponent();
            datePicker2.SelectedDate = DateTime.Now;
            datePicker1.SelectedDate = DateTime.Now.AddDays(-28);

            DataContext = this;
            userAccounts = SqliteDataAccess.getActiveUserAccounts(SqliteLogin.LoggedUserId);
            //userAccounts.Insert(0, new UserAccountModel { Account_Name = "Wszystkie", Balance = 0, Id = -1, Status = true, User_id = SqliteLogin.LoggedUserId });
            RefreshTables();
        }

        public void RefreshTables()
        {
            Categories.AddRange(SqliteDataAccess.getActiveUserCategories(SqliteLogin.LoggedUserId));
            Categories.AddRange(SqliteDataAccess.getInactiveUserCategories(SqliteLogin.LoggedUserId));
            foreach (var v in Categories) {
                CategorySelection.Add(new CategorySelectionRow(v.Category_Name,true,v));
            }
            CategoriesDatagrid.ItemsSource = CategorySelection;
            foreach (var v in userAccounts) {
                AccountSelection.Add(new AccountSelectionRow(v.Account_Name,true,v));
            }
            AccountsDatagrid.ItemsSource = AccountSelection;
        }

        private void CategoriesDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private SaveFileDialog SaveRaportDialog() {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "pdf files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {
                return saveFileDialog1;

            }
            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //siema, jestem zbyt based aby się bawić w jakieś selektywne wybieranie kategorii, wybieram wszystko i filtruję w c#-pie elo

            if (datePicker1.SelectedDate == null || datePicker2.SelectedDate == null)
            {
                MessageBox.Show("Wybierz date Od:");
                return;
            }
            if (CategorySelection.FirstOrDefault(n => n.Category_Selected == true) == null)
            {
                MessageBox.Show("Wybierz jakąś kategorię");
                return;
            }
            if (AccountSelection.FirstOrDefault(n => n.Account_Selected == true) == null)
            {
                MessageBox.Show("Wybierz jakieś konto");
                return;
            }

            var categories =
                           from cat in CategorySelection
                           where cat.Category_Selected == true
                           select cat.Category.Id;

            var accIds     =
                            from acc in AccountSelection
                            where acc.Account_Selected == true
                            select acc.Account.Id;
            var srd = SaveRaportDialog();
            if (srd == null) return;

            var output = SqliteDataAccess.LoadRaportGenerationQuery(datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"), SqliteLogin.LoggedUserId, categories.ToArray(), accIds.ToArray());

            Dictionary<string, (List<RaportQueryModel>, List<RaportQueryModel>,double)> xd = new Dictionary<string, (List<RaportQueryModel>, List<RaportQueryModel>,double)>();

            foreach (var v in AccountSelection.Where(n => n.Account_Selected == true)) {
                xd[v.Account.Account_Name] = (new List<RaportQueryModel>(), new List<RaportQueryModel>(), 0);
            }
            foreach (var v in output) {
                var vv = xd[v.AccName];
                if (v.Income)
                {
                    vv.Item1.Add(v);
                    vv.Item3 = vv.Item3 + v.Amount;
                }
                else
                {
                    vv.Item2.Add(v);
                    vv.Item3 = vv.Item3 - v.Amount;
                }
                xd[v.AccName] = vv;
            }

            RaportExport.generateRaport(srd.FileName , datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"),
                        xd,
                        CategorySelection.Where(n =>n.Category_Selected==true).Select(n=>n.Category).ToList(),
                        AccountSelection.Where(n=>n.Account_Selected==true).Select(n => n.Account).ToList());
        }
        private void GoBackToMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GoBackToMainWindow();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var v in CategorySelection) {
                v.Category_Selected = true;
            }
            CategoriesDatagrid.Items.Refresh();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (var v in CategorySelection)
            {
                v.Category_Selected = false;
            }
           
            CategoriesDatagrid.Items.Refresh();
            //CategoriesDatagrid.ItemsSource = CategorySelection;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            foreach (var v in AccountSelection) {
                v.Account_Selected = true;
            }
            AccountsDatagrid.Items.Refresh();
        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            foreach (var v in AccountSelection)
            {
                v.Account_Selected = false;
            }

            AccountsDatagrid.Items.Refresh();
            //CategoriesDatagrid.ItemsSource = CategorySelection;
        }
    }
}
