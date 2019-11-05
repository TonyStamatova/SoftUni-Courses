namespace SoftUni
{
    using System;
    using SoftUni.Data;
    using SoftUni.Data.Results;
    using System.Linq;
    using SoftUni.Models;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                Console.WriteLine(RemoveTown(db));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
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
            var employees = context.Employees
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
            var employees = context.Employees
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
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);

            var nakov = context.Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, addresses);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
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

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var result = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees")
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, result);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            return context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}"
                + Environment.NewLine
                + string.Join(
                    Environment.NewLine, 
                    e.EmployeesProjects
                        .Select(ep => ep.Project.Name)
                        .OrderBy(x => x)))
                .First();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var result = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count > 5)
                .ThenBy(d => d.Name)
                .Select(
                    d => $"{d.Name} – {d.Manager.FirstName} {d.Manager.LastName}"
                    + Environment.NewLine
                    + string.Join(
                            Environment.NewLine,
                            d.Employees
                                .OrderBy(e => e.FirstName)
                                .ThenBy(e => e.LastName)
                                .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}")
                                .ToList()))
                .ToList();

            return string.Join(Environment.NewLine, result);
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var result = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => string.Join(
                        Environment.NewLine,
                        p.Name,
                        p.Description,
                        p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)))
                .ToList();

            return string.Join(Environment.NewLine, result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(
                    e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary += (0.12m * employee.Salary);
            }

            context.SaveChanges();

            return string.Join(
                Environment.NewLine,
                employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:f2})")
                    .ToList());
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var result = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})")
                .ToList();

            return string.Join(Environment.NewLine, result);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employesProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            context.EmployeesProjects
                .RemoveRange(employesProjects);

            var projectTwo = context.Projects
                .Find(2);

            context.Projects
                .Remove(projectTwo);

            context.SaveChanges();

            return string.Join(
                Environment.NewLine,
                context.Projects
                    .Take(10)
                    .Select(p => $"{p.Name}")
                    .ToList());
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToHashSet();

            var employees = context.Employees
                .Where(e => addresses.Contains(e.Address))
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            context.Addresses
                .RemoveRange(addresses);
            context.Towns
                .Remove(
                    context.Towns
                        .First(t => t.Name == "Seattle"));

            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }
    }
}

