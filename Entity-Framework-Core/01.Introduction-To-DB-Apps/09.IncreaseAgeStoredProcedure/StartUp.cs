namespace _09.IncreaseAgeStoredProcedure
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        private static SqlConnection connection;
        private static SqlTransaction transaction;
        private static SqlCommand command;

        public static void Main()
        {
            connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            using (connection)
            {
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                }
                catch (Exception connectionEx)
                {
                    Console.WriteLine(connectionEx.Message);
                    return;
                }

                try
                {
                    using (command)
                    {
                        command = new SqlCommand(string.Empty, connection, transaction);
                        int id = int.Parse(Console.ReadLine());
                        UpdateMinionData(id);
                        PrintMinionData();
                    }

                    transaction.Commit();
                }
                catch (Exception commitException)
                {
                    Console.WriteLine($"Commit Exception Message: {commitException.Message}");

                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackException)
                    {
                        Console.WriteLine($"Rollback Exception Message: {rollbackException.Message}");
                    }
                }
            }
        }

        private static void UpdateMinionData(int id)
        {
            command.CommandText = "EXEC dbo.usp_GetOlder @Id";
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        private static void PrintMinionData()
        {
            command.CommandText = "SELECT Name, Age FROM Minions WHERE Id = @Id";

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} – {reader[1]} years old");
                }
            }
        }
    }
}
