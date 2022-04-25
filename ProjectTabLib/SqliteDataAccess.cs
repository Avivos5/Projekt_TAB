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

        public static List<TransactionModel> LoadTransactions(int userId)
        {
            var query = "select * from Transactions where user_id = :userId";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("userId", userId);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TransactionModel>(query, dynamicParameters);
                return output.ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
