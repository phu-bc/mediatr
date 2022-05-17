using MediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatRDemo.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetById(int id);

        Task<List<Employee>> GetAll();

        Task<int> Add(Employee employee);

        Task Delete(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public Task<List<Employee>> GetAll()
        {
            return _employeeContext.Employees.ToListAsync();
        }

        public Task<Employee?> GetById(int id)
        {
            return _employeeContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(Employee employee)
        {
            _employeeContext.Add(employee);
            await _employeeContext.SaveChangesAsync();

            return employee.Id;
        }

        public async Task Delete(int id)
        {
            var employee = await _employeeContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                _employeeContext.Employees.Remove(employee);
                await _employeeContext.SaveChangesAsync();
            }
        }
    }
}
