using System;
namespace P03_FootballBetting.Data.Configurations
{
    internal static class Configuration
    {
        internal static string ConnectionString 
            => @"Server=.\SQLEXPRESS;Database=FootballBookmakerSystem;Integrated Security=true";
    }
}
