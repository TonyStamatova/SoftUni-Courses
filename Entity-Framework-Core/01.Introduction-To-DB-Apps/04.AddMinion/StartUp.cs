namespace AddMinion
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        private static SqlConnection connection;
        private static SqlTransaction transaction;
        private static SqlCommand command;

        private static StringBuilder sb;

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
                        AddMinionWithVillainToDatabase();
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

        private static void AddMinionWithVillainToDatabase()
        {
            string[] minionInfo = Console.ReadLine().Split();
            string minionName = minionInfo[1];
            int age = int.Parse(minionInfo[2]);
            string town = minionInfo[3];
            
            sb = new StringBuilder();

            int townId = GetTownId(town);
            AddMinion(minionName, age, townId);
            int minionId = GetMinionId();

            string villainName = Console.ReadLine().Split()[1];
            int villainId = GetVillainId(villainName);

            AddMinionToVillainServants(minionId, villainId);
            sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void AddMinionToVillainServants(int minionId, int villainId)
        {
            command.CommandText = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
            command.Parameters.AddWithValue("@minionId", minionId);
            command.Parameters.AddWithValue("@villainId", villainId);
            command.ExecuteNonQuery();
        }

        private static int GetTownId(string town)
        {
            command.Parameters.AddWithValue("@townName", town);

            try
            {
                return TryGetTownId();
            }
            catch (NullReferenceException)
            {
                AddTown();
                sb.AppendLine($"Town {town} was added to the database.");
                return TryGetTownId();
            }
        }

        private static void AddTown()
        {
            command.CommandText = "INSERT INTO Towns (Name) VALUES (@townName)";
            command.ExecuteNonQuery();
        }

        private static int TryGetTownId()
        {
            command.CommandText = "SELECT Id FROM Towns WHERE Name = @townName";
            return (int)command.ExecuteScalar();
        }

        private static void AddMinion(string name, int age, int townId)
        {
            command.Parameters.AddWithValue("@minionName", name);
            command.Parameters.AddWithValue("@minionAge", age);
            command.Parameters.AddWithValue("@townId", townId);
            command.CommandText = "INSERT INTO Minions(Name, Age, TownId) VALUES(@minionName, @minionAge, @townId)";
            command.ExecuteNonQuery();
        }

        private static int GetMinionId()
        {
            command.CommandText = "SELECT Id FROM Minions WHERE Name = @minionName";
            return (int)command.ExecuteScalar();
        }

        private static int GetVillainId(string villainName)
        {
            command.Parameters.AddWithValue("@villainName", villainName);

            try
            {
                return TryGetVillainId();
            }
            catch (NullReferenceException)
            {
                AddVillain();
                sb.AppendLine($"Villain {villainName} was added to the database.");
                return TryGetVillainId();
            }
        }

        private static int TryGetVillainId()
        {
            command.CommandText = "SELECT Id FROM Villains WHERE Name = @villainName";
            return (int)command.ExecuteScalar();
        }

        private static void AddVillain()
        {
            int factorId = GetEvillnessFactorId();
            command.Parameters.AddWithValue("@factorId", factorId);
            command.CommandText = "INSERT INTO Villains(Name, EvilnessFactorId) VALUES(@villainName, @factorId)";
            command.ExecuteNonQuery();
        }

        private static int GetEvillnessFactorId()
        {
            command.CommandText = "SELECT Id FROM EvilnessFactors WHERE Name = 'evil'";
            return (int)command.ExecuteScalar();
        }
    }
}
