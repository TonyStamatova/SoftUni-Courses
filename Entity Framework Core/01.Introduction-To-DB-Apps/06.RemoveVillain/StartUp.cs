namespace _06.RemoveVillain
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");
            SqlTransaction transaction = null;

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
                    using (SqlCommand command = new SqlCommand(string.Empty, connection, transaction))
                    {
                        RemoveVillainFromDatabase(command);
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

        private static void RemoveVillainFromDatabase(SqlCommand command)
        {
            int villainId = int.Parse(Console.ReadLine());
            command.Parameters.AddWithValue("@villainId", villainId);
            string villainName = GetVillainName(command);

            if (string.IsNullOrWhiteSpace(villainName))
            {
                Console.WriteLine("No such villain was found.");
            }
            else
            {
                int minionsReleased = ReleaseMinions(command);
                DeleteVillain(command);
                PrintResult(villainName, minionsReleased);
            }
        }

        private static string GetVillainName(SqlCommand getName)
        {
            getName.CommandText = @"SELECT Name FROM Villains WHERE Id = @villainId";
            return (string)getName.ExecuteScalar();
        }

        private static int ReleaseMinions(SqlCommand release)
        {
            release.CommandText = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
            return (int)release.ExecuteNonQuery();
        }

        private static void DeleteVillain(SqlCommand delete)
        {
            delete.CommandText = @"DELETE FROM Villains WHERE Id = @villainId";
            delete.ExecuteNonQuery();
        }

        private static void PrintResult(string villainName, int minionsReleased)
        {
            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{minionsReleased} minions were released.");
        }
    }
}
