namespace _01.InitialSetup
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database={0};Integrated Security=true";
            SqlConnection connection = new SqlConnection(string.Format(connectionString, "master"));

            try
            {
                connection.Open();

                using (connection)
                {
                    CreateMinionsDB(connection);
                }

                connection = new SqlConnection(string.Format(connectionString, "MinionsDB"));
                connection.Open();

                using (connection)
                {
                    CreateTables(connection);
                    InsertValues(connection);
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
        }

        private static void CreateMinionsDB(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("CREATE DATABASE MinionsDB", connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static void CreateTables(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))");
            sb.AppendLine("CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,");
            sb.Append("Name VARCHAR(50),");
            sb.Append("CountryCode INT FOREIGN KEY REFERENCES Countries(Id))");
            sb.AppendLine("CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,");
            sb.Append("Name VARCHAR(30),");
            sb.Append("Age INT,");
            sb.Append("TownId INT FOREIGN KEY REFERENCES Towns(Id))");
            sb.AppendLine("CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))");
            sb.AppendLine("CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY,");
            sb.Append("Name VARCHAR(50),");
            sb.Append("EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))");
            sb.AppendLine("CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id),");
            sb.Append("VillainId INT FOREIGN KEY REFERENCES Villains(Id),");
            sb.Append("CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))");

            using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static void InsertValues(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Countries ([Name]) ");
            sb.Append("VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')");
            sb.AppendLine("INSERT INTO Towns ([Name], CountryCode) ");
            sb.Append("VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),");
            sb.Append("('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)");
            sb.AppendLine("INSERT INTO Minions (Name,Age, TownId) ");
            sb.Append("VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),");
            sb.Append("('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)");
            sb.AppendLine("INSERT INTO EvilnessFactors (Name) ");
            sb.Append("VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')");
            sb.AppendLine("INSERT INTO Villains (Name, EvilnessFactorId) ");
            sb.Append("VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)");
            sb.AppendLine("INSERT INTO MinionsVillains (MinionId, VillainId) ");
            sb.Append("VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)");
           
            using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
