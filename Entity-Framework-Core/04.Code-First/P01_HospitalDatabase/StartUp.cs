﻿namespace P01_HospitalDatabase
{
    using P01_HospitalDatabase.Data;

    using Microsoft.EntityFrameworkCore;

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
