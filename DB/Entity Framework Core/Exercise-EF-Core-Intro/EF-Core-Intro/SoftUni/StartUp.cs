using System.Globalization;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //To check the output uncomment the following lines and insert method name

            //SoftUniContext dbContext = new SoftUniContext();
            //string output = *Method name*(dbContext);
            //Console.WriteLine(output);
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

        //08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(e => e.Town.Name)
                .ThenBy(e => e.AddressText)
                .Take(10)
                .Select(e => new
                {
                    EmployeeCount = e.Employees.Count,
                    TownName = e.Town.Name,
                    e.AddressText
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }
            return sb.ToString().TrimEnd(); 
        }

        //09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var targetEmployee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .OrderBy(ep => ep.Project.Name)
                        .Select(ep => ep.Project.Name)
                        .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in targetEmployee)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"{project}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        }).ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    Date = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.Date);
            }
            return sb.ToString().TrimEnd();
        }

        //12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .ToArray();

            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }

        //13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary,
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }

        //14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var employeesProjectToDelete = context.EmployeesProjects.FirstOrDefault(ep => ep.ProjectId == 2);
            context.EmployeesProjects.Remove(employeesProjectToDelete);

            var projectToDelete = context.Projects.Find(2);
            context.Projects.Remove(projectToDelete);

            //context.SaveChanges();

            var projects = context.EmployeesProjects
                .Take(10)
                .Select(p => p.Project.Name)
                .ToArray();

            foreach (var project in projects)
            {
                stringBuilder.AppendLine($"{project}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var townToRemove = context.Towns
                .Where(t => t.Name == "Seattle")
                .FirstOrDefault();

            var addressesToRemove = context.Addresses
                .Where(a => a.TownId == townToRemove.TownId)
                .ToArray();

            foreach (var address in addressesToRemove)
            {
                var employeeAddresses = context.Employees
                    .Where(e => e.Address == address)
                    .ToArray();

                foreach (var employee in employeeAddresses)
                {
                    employee.AddressId = null;
                }
            }

            context.Addresses.RemoveRange(addressesToRemove);
            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            stringBuilder.AppendLine($"{addressesToRemove.Length} addresses in Seattle were deleted");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}