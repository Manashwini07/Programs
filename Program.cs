using System;
using System.Data.SQLite;


namespace BankManagementSystem
{
    class Program
    {
        static string connectionString = "Data Source=bank.db;Version=3";
        
        static void Main(string[]args)
        {
            InitializeDatabase();
            while (true)
            {
                Console.WriteLine("\n---Bank Management System ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Transaction History");
                Console.WriteLine("6. Exit");
                Console.Write("Select an Option");
                var choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        CreateAccunt();
                        break;
                    case "2":
                        Deposit();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        CheckBalance();
                        break;
                    case "5":
                        ShowTrasnactions();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
        static void InitialializeDatabase()
        {
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            String accountsTable = @"CREATE TABLE IF NOT EXISTS Accounts(AccountID INTEGER PRIMARY KEY AUTOINCREMENT,Name TEXT OR NULL, Balance REAL NOT NULL DEFAULT 0);"
            String transactionsTable = @"CREATE TABLE IF NOT EXISTS Transactions(TransactionID INTEGER PRIMARY KEY AUTOINCREMENT, AccountID INTEGER, Type TEXT, Amount REAL, Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP, FOREIGN KEY(Account ID) REFERENCES Accounts(AccountsID);";

            new SQLiteCommand(accountsTable, conn).ExecuteNonQuery();
            new SQLiteCommand(transactionsTable, conn).ExecuteNonQuery();

        }

        static void CreareAccount()
        {
            Console.Write("Enter your name: ");
            string name= Console.ReadLine();

            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Accounts (Name, Balance) VALUES (@name,0)";
            var cmd= new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Account Created Successfully");
            
        }
        static void Deposit()
        {
            Console.WriteLine("Enter Account ID:");
            int id= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amount to Deposit");

        }
    }
}