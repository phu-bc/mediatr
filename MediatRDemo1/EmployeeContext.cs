using MediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatRDemo
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions options) : base(options)
        {
            InitData();
        }

        private void InitData()
        {
            var employee1 = new Employee
            {
                FirstName = "William",
                LastName = "Shakespeare",
                Email = "william@gmail.com"
            };
            Employees.Add(employee1);

            var employee2 = new Employee
            {
                FirstName = "George",
                LastName = "Washington",
                Email = "george@gmail.com"
            };

            Employees.Add(employee2);
        }
    }
}
