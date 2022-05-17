using MediatR;
using MediatRDemo.Models;
using MediatRDemo.Queries;
using MediatRDemo.Repositories;

namespace MediatRDemo.Handlers
{
    public class GetEmployeByIdQueryHandler : IRequestHandler<GetEmployeByIdQuery, Employee?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<Employee?> Handle(GetEmployeByIdQuery request, CancellationToken cancellationToken)
        {
            return _employeeRepository.GetById(request.EmployeeId);
        }
    }
}
