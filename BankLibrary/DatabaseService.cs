using System;
using System.Data;
using System.Data.SqlClient;

namespace BankLibrary
{
    public static class DatabaseService
    {
        private static readonly string ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BankDB.mdf;Database=BankDB;";

        // Checks if a newly generated account number is unique
        public static bool AccountNumberExists(string accountNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Accounts WHERE AccountNumber = @AccountNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        // DISCONNECTED MODEL: loads all accounts into a DataTable
        public static DataTable GetAllAccounts()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Accounts";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        // DISCONNECTED MODEL: Enters new account from UI
        public static bool InsertAccount(string firstName, string lastName, string accountNumber, decimal balance, char accountType)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Accounts (FirstName, LastName, AccountNumber, Balance, AccountType) " +
                               "VALUES (@FirstName, @LastName, @AccountNumber, @Balance, @AccountType)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Balance", balance);
                    command.Parameters.AddWithValue("@AccountType", accountType);

                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.InsertCommand = command;
                        connection.Open();
                        adapter.InsertCommand.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
            }
        }

        // DISCONNECTED MODEL: Updates Account balance
        public static void UpdateAccountBalance(string accountNumber, decimal newBalance)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE Accounts SET Balance = @Balance WHERE AccountNumber = @AccountNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Balance", newBalance);
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        //DISCONNECTED MODEL: Stores transactions into a log
        public static void InsertTransactionLog(string accountNumber, decimal amount, char transactionType)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Transactions (AccountNumber, Amount, TransactionType) " +
                               "VALUES (@AccountNumber, @Amount, @TransactionType)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@TransactionType", transactionType);

                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.InsertCommand = command;
                        connection.Open();
                        adapter.InsertCommand.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }
        // DISCONNECTED MODEL: loads all accounts into DataTable
        public static DataTable GetAllTransactions()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Transactions";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}