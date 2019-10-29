namespace MinionNames
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            try
            {
                connection.Open();

                using (connection)
                {
                    int villainId = int.Parse(Console.ReadLine());
                    GetVillainName(connection, villainId);
                    GetMinionsInfo(connection, villainId);

                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
        }

        private static void GetVillainName(SqlConnection connection, int villainId)
        {
            using (SqlCommand getName = new SqlCommand("SELECT Name FROM Villains WHERE Id = @id", connection))
            {
                getName.Parameters.AddWithValue("@id", villainId);
                string villainName = (string)getName.ExecuteScalar();

                if (string.IsNullOrWhiteSpace(villainName))
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    Environment.Exit(0);
                }

                Console.WriteLine($"Villain: {villainName}");
            }
        }

        private static void GetMinionsInfo(SqlConnection connection, int villainId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS Row, m.Name, m.Age ");
            sb.Append("FROM Villains AS v ");
            sb.Append("JOIN MinionsVillains AS mv ");
            sb.Append("ON v.Id = mv.VillainId ");
            sb.Append("JOIN Minions AS m ");
            sb.Append("ON m.Id = mv.MinionId ");
            sb.Append("WHERE mv.VillainId = @id");                   

            using (SqlCommand getMinions = new SqlCommand(sb.ToString(), connection))
            {
                getMinions.Parameters.AddWithValue("@id", villainId);

                using (SqlDataReader reader = getMinions.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                        return;
                    }

                    PrintMinionsInfo(reader);
                }
            }
        }

        private static void PrintMinionsInfo(SqlDataReader reader)
        {
            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {
                sb.AppendLine($"{reader[0]}. {reader[1]} {reader[2]}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
