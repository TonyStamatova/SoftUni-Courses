namespace P03_SalesDatabase
{
    using P03_SalesDatabase.Data;

    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new SalesContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
