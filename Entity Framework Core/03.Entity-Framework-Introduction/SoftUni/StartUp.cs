namespace SoftUni
{
    using System;
    using System.Collections.Generic;
    using SoftUni.Data;
    using SoftUni.Data.Results;
    using System.Linq;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main()
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                Console.WriteLine(GetEmployeesInPeriod(db));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            List<EmployeeResultModel> employees = context.Employees
                .Select(e => new EmployeeResultModel
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary,
                })
                .ToList();

            return string.Join(Environment.NewLine, employees);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            List<EmployeeSalaryResultModel> employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new EmployeeSalaryResultModel
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary,
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            return string.Join(Environment.NewLine, employees);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            List<ResearchAndDevelopmentResultModel> employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new ResearchAndDevelopmentResultModel
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            return string.Join(Environment.NewLine, employees);
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);

            Employee nakov = context.Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            List<string> addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, addresses);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            List<EmployeeProjectResultModel> employees = context.Employees
                .Where(e => e.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new EmployeeProjectResultModel
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new ProjectsResultModel
                        {
                            Name = ep.Project.Name,
                            StartDate = ep.Project.StartDate,
                            EndDate = ep.Project.EndDate
                        })
                        .ToList()
                })
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, employees);
        }
    }
}

