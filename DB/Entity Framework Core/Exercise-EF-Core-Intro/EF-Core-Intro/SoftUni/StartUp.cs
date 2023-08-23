using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
        }
        //03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50_000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee? employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee!.Address = newAddress;
            context.SaveChanges();

            string[] employeeAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address!.AddressText)
                .ToArray();
            return string.Join(Environment.NewLine, employeeAddresses);
        }
        //07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var employees = context.Employees
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManFirst = e.Manager.FirstName,
                    ManLast = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjName = ep.Project.Name,
                            ProjStartDate = ep.Project.StartDate,
                            ProjEndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                        }).ToArray()

                }).ToArray();

            foreach (var emp in employees)
            {
                stringBuilder.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManFirst} {emp.ManLast}");

                foreach (var proj in emp.Projects)
                {
                    stringBuilder.AppendLine(
                        $"--{proj.ProjName} - {proj.ProjStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {proj.ProjEndDate}");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}