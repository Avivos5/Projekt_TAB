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
        List<TransactionDatagridModel> transactions = new List<TransactionDatagridModel>();
        List<UserAccountModel> Accounts = new List<UserAccountModel>();
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

            Accounts_ComboBox.DataContext = this;
            userAccounts = SqliteDataAccess.getActiveUserAccounts(SqliteLogin.LoggedUserId);
            //userAccounts.Insert(0, new UserAccountModel { Account_Name = "Wszystkie", Balance = 0, Id = -1, Status = true, User_id = SqliteLogin.LoggedUserId });
            Accounts_ComboBox.SelectedIndex = 0;

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
                MessageBox.Show("Wybierz jakąś kategorię");
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

            RaportExport.generateRaport(srd.FileName ,Accounts_ComboBox.Text, datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"),
                        xd,
                        CategorySelection.Where(n =>n.Category_Selected==true).Select(n=>n.Category).ToList(),
                        AccountSelection.Where(n=>n.Account_Selected==true).Select(n => n.Account).ToList());


            /*            var categories = 
                           from cat in CategorySelection
                           where cat.Category_Selected == true
                           select cat.Category.Id;

                        var accIds =
                            from acc in AccountSelection
                            where acc.Account_Selected == true
                            select acc.Account.Id;
                        Dictionary<int, (double,string)> test = new Dictionary<int, (double,string)>();
                        Dictionary<string, RaportQueryModel> xd = new Dictionary<string, RaportQueryModel>();
                        foreach (var v in accIds)
                        {
                            var output = SqliteDataAccess.LoadRaportGenerationQuery(datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"), SqliteLogin.LoggedUserId, categories.ToArray(), v);

                                foreach (var b in output)
                                {
                                    xd[b.Income.ToString()[0] + b.AccName + b.Name] = b;
                                }

                            var asd = test[v];
                            asd.Item1 = output.Sum(n => n.Amount);
                           // asd.Item2 = v.Account.Account_Name;
                        }
                        //0 -rekord 1 - bilans 2 - label
                        List<(string, double, int)> rows = new List<(string, double, int)>();

                        foreach (var z in AccountSelection)
                        {

                            foreach (var x in CategorySelection)
                            {
                                if (!z.Account_Selected || !x.Category_Selected) continue;

                            }
                        }
            */
            /*            foreach (var v in output)
                            xd[v.Income.ToString()[0]+ v.AccName + v.Name ] = v;
            */
            /*            RaportExport.generateRaport(Accounts_ComboBox.Text, datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"),
                        bilans,
                        xd.Values.ToArray(), srd.FileName);
            */
            /*            RaportExport.generateRaport(Accounts_ComboBox.Text, datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"),
                        bilans,
                        xd.Values.ToArray(), srd.FileName);
            */

            /*            var transakcje = 
                           from trans in SqliteDataAccess.LoadTransactionsByDateToDateAndAccount(datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"), SqliteLogin.LoggedUserId, Accounts_ComboBox.Text)
                           from c in categories
                           where trans.Category_Id == c.Id
                           select trans;
                        catrow[] rows = new catrow[categories.Count()];
                        Dictionary<string,(string,double,double)> xd = new Dictionary<string, (string, double, double)>();

                        foreach (var v in categories) {
                            xd[v.Id.ToString()] = (v.Category_Name,0,0);
                        }
                        double bilans=0;
                        foreach (var v in transactions)
                        {
                            var xx = xd[v.Category_Id.ToString()];
                            if (v.Income)
                            {
                                xx.Item2 += v.Transaction_Amount;
                                bilans += v.Transaction_Amount;
                            }
                            else
                            {
                                xx.Item3 += v.Transaction_Amount;
                                bilans -= v.Transaction_Amount;
                            }
                            xd[v.Category_Id.ToString()] = xx;
                        }



                        RaportExport.generateRaport(Accounts_ComboBox.Text, datePicker1.SelectedDate.Value.ToString("yyyy-MM-dd"), datePicker2.SelectedDate.Value.ToString("yyyy-MM-dd"),
                          bilans, 
                          xd.Values.ToArray(),srd.FileName);
            */
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
    }
}
