namespace _07.PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            try
            {
                connection.Open();
                List<string> minions = new List<string>();

                using (connection)
                {
                    SqlDataReader reader = GetMinionNames(connection);

                    if (reader == null || !reader.HasRows)
                    {
                        return;
                    }

                    using (reader)
                    {
                        minions = IndexMinions(reader);
                    }                    
                }

                PrintResult(minions);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
        }

        private static void PrintResult(List<string> minions)
        {
            int startIndex = 0;
            int endIndex = minions.Count - 1;

            while (startIndex <= endIndex)
            {
                Console.WriteLine(minions[startIndex]);
                startIndex++;

                if (startIndex > endIndex)
                {
                    break;
                }

                Console.WriteLine(minions[endIndex]);
                endIndex--;
            }
        }

        private static SqlDataReader GetMinionNames(SqlConnection connection)
        {
            SqlCommand getMinions = new SqlCommand("SELECT Name FROM Minions ORDER BY Id", connection);

            using (getMinions)
            {
                return getMinions.ExecuteReader();
            }
        }

        private static List<string> IndexMinions(SqlDataReader reader)
        {
            List<string> minions = new List<string>();

            while (reader.Read())
            {
                minions.Add((string)reader[0]);
            }

            return minions;
        }
    }
}
