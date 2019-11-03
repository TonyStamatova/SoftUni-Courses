namespace _05.ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;

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
                    StringBuilder sb = new StringBuilder();

                    using (SqlCommand command = new SqlCommand(string.Empty, connection, transaction))
                    {
                        if (ChangeTownNames(command, sb))
                        {
                            PrintChangedNames(command, sb);
                        }                        
                    }

                    transaction.Commit();
                    Console.WriteLine(sb.ToString().TrimEnd());
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

        private static bool ChangeTownNames(SqlCommand command, StringBuilder sb)
        {
            string countryName = Console.ReadLine();
            command.Parameters.AddWithValue("@countryName", countryName);
            command.CommandText = "UPDATE Towns SET Name = UPPER(Name) " +
                "WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                        
            int affectedTowns = command.ExecuteNonQuery();

            if (affectedTowns == 0)
            {
                sb.AppendLine("No town names were affected.");
                return false;
            }

            sb.AppendLine($"{affectedTowns} town names were affected.");
            return true;
        }

        private static void PrintChangedNames(SqlCommand command, StringBuilder sb)
        {
            command.CommandText = "SELECT Name FROM Towns " +
                "WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            SqlDataReader reader = command.ExecuteReader();
            List<string> towns = new List<string>();

            using (reader)
            {
                while (reader.Read())
                {
                    towns.Add((string)reader[0]);
                }
            }

            sb.AppendLine($"[{string.Join(", ", towns)}]");
        }
    }
}
