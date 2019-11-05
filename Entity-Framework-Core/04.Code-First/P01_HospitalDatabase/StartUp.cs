namespace P01_HospitalDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new HospitalDbContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
