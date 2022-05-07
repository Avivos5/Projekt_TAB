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
            //var dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("userId", userId);
            //var query = "select Transactions.*, User_Categories.name as Category_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id where Transactions.user_id = :userId";
            
            
            

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TransactionDatagridModel>(@"select Transactions.*, User_Categories.name as Category_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id where Transactions.user_id = @UserId", new {UserId = userId});
               
                return output.ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
