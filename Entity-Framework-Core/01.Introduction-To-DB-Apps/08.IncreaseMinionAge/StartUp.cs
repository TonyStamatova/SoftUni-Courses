namespace _08.IncreaseMinionAge
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

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
                        List<int> idList = ReadIds();
                        UpdateMinionData(idList);
                        PrintMinionsData();
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

        private static List<int> ReadIds()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
        }

        private static void UpdateMinionData(List<int> idList)
        {
            command.CommandText = "UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1" + 
                " WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", 0);

            foreach (var id in idList)
            {
                command.Parameters[0].Value = id;
                command.ExecuteNonQuery();
            }
        }

        private static void PrintMinionsData()
        {
            command.CommandText = "SELECT Name, Age FROM Minions";

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }
            }
        }
    }
}
