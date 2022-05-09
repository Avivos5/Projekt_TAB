using Dapper;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTabLib
{
    public class SqliteDataAccess
    {

        public static List<TransactionDatagridModel > LoadTransactions(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    UserId = userId
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id where Transactions.user_id = @UserId;";
                var output = cnn.Query<TransactionDatagridModel>(sql, p);
               
                return output.ToList();
            }
        }

        public static List<UserCategoryModel> getUserCategories(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    UserId = userId
                };

                string sql = @"select id, user_id, name as category_name, status from User_Categories where user_id = @userId";
                var output = cnn.Query<UserCategoryModel>(sql, p);

                return output.ToList();
            }
        }

        public static List<UserAccountModel> getUserAccounts(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    UserId = userId
                };

                string sql = @"select id, user_id, name as account_name, balance, status from Accounts where user_id = @userId";
                var output = cnn.Query<UserAccountModel>(sql, p);

                return output.ToList();
            }
        }

        public static void addTransaction(Object newTransaction)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("INSERT INTO Transactions (user_id, category_id, account_id, datetime, name, transaction_amount, income, current_amount) VALUES (@User_Id, @Category_Id, @Account_Id, @DateTime, @Name, @Transaction_Amount, @Income, @Current_Amount)", newTransaction);

            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
