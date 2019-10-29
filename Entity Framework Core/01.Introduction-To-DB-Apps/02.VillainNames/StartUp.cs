namespace VillainNames
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
                    SqlDataReader reader = GetVillainNames(connection);

                    if (reader == null)
                    {
                        return;
                    }

                    using (reader)
                    {
                        PrintResult(reader);
                    }
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }            
        }

        private static SqlDataReader GetVillainNames(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT v.Name, COUNT(*) AS MinionsCount ");
            sb.Append("FROM Villains AS v ");
            sb.Append("JOIN MinionsVillains AS mv ");
            sb.Append("ON v.Id = mv.VillainId ");
            sb.Append("GROUP BY v.Name ");
            sb.Append("HAVING COUNT(*) > 3 ");
            sb.Append("ORDER BY COUNT(*)");

            using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
            {
                return command.ExecuteReader();
            }
        }

        private static void PrintResult(SqlDataReader reader)
        {
            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {
                sb.AppendLine($"{reader[0]} - {reader[1]}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
