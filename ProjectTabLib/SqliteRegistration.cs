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
    public class SqliteRegistration
    {
        public static int LoggedUserId;
        public static string LoggedUserLogin;

        public static int RegisterUser(string login, string password)
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("INSERT INTO Users (login, password) VALUES (@Login, @Password)", new {Login = login, Password = password});
                return affectedRows;
            }
        }

        public static bool CheckIfExist(string login)
        {
            var query = "SELECT * from Users WHERE login = :login";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("login", login);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>(query, dynamicParameters).FirstOrDefault();

                if (output == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
