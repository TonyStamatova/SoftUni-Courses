﻿namespace MiniORM.App
{
    using System.Linq;

    using MiniORM.App.Data;
    using MiniORM.App.Data.Entities;

    public class StartUp
    {
        public static void Main()
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=MiniORM;Integrated Security=true";

            SoftUniDbContext context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            Employee employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
