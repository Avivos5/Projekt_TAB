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

        //Transactions-----------------------

        public static List<TransactionDatagridModel> LoadTransactions(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    UserId = userId
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where Transactions.user_id = @UserId";
                var output = cnn.Query<TransactionDatagridModel>(sql, p);

                return output.ToList();
            }
        }

        public static List<TransactionDatagridModel> LoadTransactionsByCategorieName(String category_name, int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    name = category_name,
                    Id = userId
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where (User_Categories.name = @name and Transactions.user_id = @Id)";
                var output = cnn.Query<TransactionDatagridModel>(sql, p);

                return output.ToList();
            }
        }

        public static List<TransactionDatagridModel> LoadTransactionsByAccountName(String account_name, int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    name = account_name,
                    Id = userId
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where (Accounts.name = @name and Transactions.user_id = @Id)";
                var output = cnn.Query<TransactionDatagridModel>(sql, p);

                return output.ToList();
            }
        }

        public static List<TransactionDatagridModel> LoadTransactionsByAccountNameAndCategoriesName(String account_name, String category_name, int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    acc_name = account_name,
                    Id = userId,
                    cat_name = category_name
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where (Accounts.name = @acc_name and Transactions.user_id = @Id and User_Categories.name = @cat_name)";
                var output = cnn.Query<TransactionDatagridModel>(sql, p);

                return output.ToList();
            }
        }

        public static List<TransactionDatagridModel> LoadTransactionsByDateToDate(String dateOne, String dateTwo, int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    dateOne = dateOne,
                    Id = userId,
                    dateTwo = dateTwo,
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where  (Transactions.user_id = @Id AND datetime BETWEEN @dateOne and @dateTwo)";
                var output = cnn.Query<TransactionDatagridModel>(sql, p);

                return output.ToList();
            }
        }
        public static List<TransactionDatagridModel> LoadTransactionsByDateToDateAndCategories(String dateOne, String dateTwo, int userId, String categoryName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    Id = userId,

                    dateOne = dateOne,

                    dateTwo = dateTwo,
                    categoryName = categoryName,
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where  (Transactions.user_id = @Id AND( datetime BETWEEN @dateOne and @dateTwo) and User_Categories.name = @categoryName)";
                var output = cnn.Query<TransactionDatagridModel>(sql, p);

                return output.ToList();
            }
        }


        public static List<TransactionDatagridModel> LoadTransactionsByDateToDateAndCategoriesAndAccounts(String dateOne, String dateTwo, int userId, String categoryName, String accountName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    categoryName = categoryName,
                    dateOne = dateOne,
                    Id = userId,
                    dateTwo = dateTwo,
                    accountsName = accountName,
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where  (Transactions.user_id = @Id AND datetime BETWEEN @dateOne and @dateTwo and User_Categories.name = @categoryName and Accounts.name = @accountsName)";
                var output = cnn.Query<TransactionDatagridModel>(sql, p);

                return output.ToList();
            }
        }
        public static List<TransactionDatagridModel> LoadTransactionsByAccountName(String account_name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    name = account_name
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where Accounts.name = @name";
                var output = cnn.Query<TransactionDatagridModel>(sql, p);

                return output.ToList();
            }
        }
        public static List<TransactionDatagridModel> LoadTransactionsByDateToDateAndAccount(String dateOne, String dateTwo, int userId, String accountName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    dateOne = dateOne,
                    Id = userId,
                    dateTwo = dateTwo,
                    accountsName = accountName,
                };

        string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where  (Transactions.user_id = @Id AND datetime BETWEEN @dateOne and @dateTwo and Accounts.name = @accountsName)";
        var output = cnn.Query<TransactionDatagridModel>(sql, p);

                return output.ToList();
            }

        }
        public static List<RaportQueryModel> LoadRaportGenerationQuery(String dateOne, String dateTwo, int userId, int[] categories,int[] accounts)
        {
            /*            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                        {
                            var p = new
                            {
                                dateOne = dateOne,
                                Id = userId,
                                dateTwo = dateTwo,
                                accounts = accounts,
                                categories = categories
                            };

                    string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where  (Transactions.user_id = @Id AND datetime BETWEEN @dateOne and @dateTwo) AND Accounts.Id IN @accounts AND Transactions.category_id IN @categories";
                    var output = cnn.Query<TransactionDatagridModel>(sql, p);
                            return output.ToList();
                        }
            */
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    dateOne = dateOne,
                    Id = userId,
                    dateTwo = dateTwo,
                    accounts = accounts,
                    categories = categories
                };

                string sql = @"select Accounts.name as AccName, User_Categories.name as Name,  SUM(Transactions.Transaction_Amount) as Amount, Transactions.Income as Income from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where  (Transactions.user_id = @Id AND datetime BETWEEN @dateOne and @dateTwo) AND Accounts.Id IN @accounts AND Transactions.category_id IN @categories GROUP BY Accounts.name, User_Categories.name, Transactions.Income ORDER BY Income ASC, AccName,Name";
                var output = cnn.Query<RaportQueryModel>(sql, p);
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

        public static void updateTransaction(Object updatedTransaction)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("UPDATE Transactions SET Category_Id = @Category_Id, Account_Id = @Account_Id, DateTime = @DateTime, Name = @Name, Transaction_Amount = @Transaction_Amount, Income = @Income, Current_Amount = @Current_Amount WHERE Id = @Id", updatedTransaction);

            }
        }

        public static int DeleteTransaction(int transactionId)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {

                var affectedRows = connection.Execute("Delete from Transactions Where Id = @Id", new { Id = transactionId });
                return affectedRows;
            }
        }

        public static TransactionDatagridModel SelectTransactionById(int transactionId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    Id = transactionId
                };

                string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where Transactions.id = @Id";
                TransactionDatagridModel output = cnn.Query<TransactionDatagridModel>(sql, p).FirstOrDefault();

                return output;
            }
        }

        //Categories-----------------------

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
        
        public static List<UserCategoryModel> getActiveUserCategories(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    UserId = userId
                };

                string sql = @"select id, user_id, name as category_name, status from User_Categories where user_id = @userId and status = true";
                var output = cnn.Query<UserCategoryModel>(sql, p);

                return output.ToList();
            }
        }

        public static List<UserCategoryModel> getInactiveUserCategories(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    UserId = userId
                };

                string sql = @"select id, user_id, name as category_name, status from User_Categories where user_id = @userId and status = false";
                var output = cnn.Query<UserCategoryModel>(sql, p);

                return output.ToList();
            }
        }

        public static void addCategorie(Object newCategorie)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("INSERT INTO User_Categories (user_id, name, status) VALUES (@User_Id, @Name, @Status)", newCategorie);

            }
        }

        public static bool CheckIfCategoryExist(int userId, string name)
        {
            var query = "SELECT * from User_Categories WHERE user_id = :user_id and name = :name";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("user_id", userId);
            dynamicParameters.Add("name", name);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserCategoryModel>(query, dynamicParameters).FirstOrDefault();

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

        public static bool CheckIfEditCategoryExist(int userId, string name, int currentCatId)
        {
            var query = "SELECT * from User_Categories WHERE id != :currentCatId and user_id = :user_id and name = :name";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("currentCatId", currentCatId);
            dynamicParameters.Add("user_id", userId);
            dynamicParameters.Add("name", name);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserCategoryModel>(query, dynamicParameters).FirstOrDefault();

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

        public static UserCategoryModel SelectCategorieById(int categorieId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    Id = categorieId
                };

                //string sql = @"select Transactions.*, User_Categories.name as Category_Name, Accounts.name as Account_Name from Transactions  LEFT JOIN User_Categories ON Transactions.user_id = User_Categories.user_id and Transactions.category_id = User_Categories.id LEFT JOIN Accounts ON Transactions.user_id = Accounts.user_id and Transactions.account_id = Accounts.id where Transactions.id = @Id";
                string sql = @"select id, user_id, User_Categories.name as Category_Name, status from User_Categories where Id = @Id";
                UserCategoryModel output = cnn.Query<UserCategoryModel>(sql, p).FirstOrDefault();

                return output;
            }
        }

        

        public static void updateCategory(Object updatedCategory)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("UPDATE User_Categories SET Name = @Name, Status = @Status WHERE Id = @Id", updatedCategory);

            }
        }


        //Accounts-----------------------

        public static void addAccount(Object newAccount)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("INSERT INTO Accounts (user_id, name, balance, status) VALUES (@User_Id, @Name, @Balance, @Status)", newAccount);

            }
        }

        public static bool CheckIfAccountExist(int userId, string name)
        {
            var query = "SELECT * from Accounts WHERE user_id = :user_id and name = :name";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("user_id", userId);
            dynamicParameters.Add("name", name);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserCategoryModel>(query, dynamicParameters).FirstOrDefault();

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

        public static bool CheckIfEditAccountExist(int userId, string name, int currentAccId)
        {
            var query = "SELECT * from Accounts WHERE id != :currentAccId and user_id = :user_id and name = :name";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("currentAccId", currentAccId);
            dynamicParameters.Add("user_id", userId);
            dynamicParameters.Add("name", name);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserCategoryModel>(query, dynamicParameters).FirstOrDefault();

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

        public static List<UserAccountModel> getActiveUserAccounts(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    UserId = userId
                };

                string sql = @"select id, user_id, name as account_name, balance, status from Accounts where user_id = @userId and status = true";
                var output = cnn.Query<UserAccountModel>(sql, p);

                return output.ToList();
            }
        }

        public static List<UserAccountModel> getInactiveUserAccounts(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    UserId = userId
                };

                string sql = @"select id, user_id, name as account_name, balance, status from Accounts where user_id = @userId and status = false";
                var output = cnn.Query<UserAccountModel>(sql, p);

                return output.ToList();
            }
        }


        public static UserAccountModel SelectAccountById(int accountId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    Id = accountId
                };

                string sql = @"select id, user_id, Accounts.name as Account_Name, status from Accounts where Id = @Id";
                UserAccountModel output = cnn.Query<UserAccountModel>(sql, p).FirstOrDefault();

                return output;
            }
        }

        public static void updateAccount(Object updatedAccount)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var affectedRows = cnn.Execute("UPDATE Accounts SET Name = @Name, Status = @Status WHERE Id = @Id", updatedAccount);

            }
        }

        public static void updateAccountBalance(int id, double amount, bool income)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                var accBalanceUpdate = new
                {
                    Id = id,
                    Amount = amount,
                };

                if (income == true)
                {
                    cnn.Execute("update Accounts set balance = balance + @Amount where id = @Id", accBalanceUpdate);
                }
                else
                {
                    cnn.Execute("update Accounts set balance = balance - @Amount where id = @Id", accBalanceUpdate);
                }


            }
        }

        public static void updateAccountBalanceOnEdit(int transactionId, int accountId, double amount, bool income)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var query = "select * from Transactions where id = :id";
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("id", transactionId);
                var tranToEdit = cnn.Query<TransactionModel>(query, dynamicParameters).FirstOrDefault();

                if (tranToEdit.Account_Id == accountId)
                {
                    double finalTransactionBalance = 0;

                    if (tranToEdit.Income)
                        finalTransactionBalance -= tranToEdit.Transaction_Amount;
                    else
                        finalTransactionBalance += tranToEdit.Transaction_Amount;

                    if (income)
                        finalTransactionBalance += amount;
                    else
                        finalTransactionBalance -= amount;

                    cnn.Execute("update Accounts set balance = balance + @Amount where id = @Id", new { Id = accountId, Amount = finalTransactionBalance });
                }
                else
                {
                    if (tranToEdit.Income)
                        cnn.Execute("update Accounts set balance = balance - @Amount where id = @Id", new { Id = tranToEdit.Account_Id, Amount = tranToEdit.Transaction_Amount });
                    else
                        cnn.Execute("update Accounts set balance = balance + @Amount where id = @Id", new { Id = tranToEdit.Account_Id, Amount = tranToEdit.Transaction_Amount });

                    if (income)
                        cnn.Execute("update Accounts set balance = balance + @Amount where id = @Id", new { Id = accountId, Amount = amount });
                    else
                        cnn.Execute("update Accounts set balance = balance - @Amount where id = @Id", new { Id = accountId, Amount = amount });

                }
            }
        }

        public static void updateAccountBalanceonDelete(int accId, double amount, bool income)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                if (income)
                    cnn.Execute("update Accounts set balance = balance - @Amount where id = @Id", new { Id = accId, Amount = amount });
                else
                    cnn.Execute("update Accounts set balance = balance + @Amount where id = @Id", new { Id = accId, Amount = amount });
            }
        }

        //Balance-------------

        public static double countTotalBalance(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var p = new
                {
                    Id = userId,
                };

                string sql = @"select sum(balance) from Accounts where user_id = @Id";
                var output = cnn.ExecuteScalar<double>(sql, p);

                //var tmp = output
                return output;
            }
        }
         




        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

       
    }
}
