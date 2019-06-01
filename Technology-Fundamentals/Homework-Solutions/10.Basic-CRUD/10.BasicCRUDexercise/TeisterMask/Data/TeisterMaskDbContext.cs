using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeisterMask.Models;

namespace TeisterMask.Data
{
    public class TeisterMaskDbContext: DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-VN8E4A8\SQLEXPRESS;Database=MeisterTaskDbContext;Integrated Security=True;");
        }
    }
}
