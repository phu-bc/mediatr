using MediatR;
using MediatRDemo.Models;

namespace MediatRDemo.Queries
{
    public class GetEmployeByIdQuery : IRequest<Employee>
    {
        public int EmployeeId { get; set; }
    }
}
