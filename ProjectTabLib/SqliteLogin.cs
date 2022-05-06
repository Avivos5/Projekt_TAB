using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTabLib
{
    public class SqliteLogin
    {

        public static int LoggedUserId;
        public static string LoggedUserLogin;

        public static bool CheckUserLogin(string login, string password)
        {
            var query = "SELECT * from Users WHERE login = :login AND password = :password";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("login", login);
            dynamicParameters.Add("password", password);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>(query, dynamicParameters).FirstOrDefault();

                if(output != null)
                {
                    LoggedUserId = output.Id;
                    LoggedUserLogin = output.Login;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
