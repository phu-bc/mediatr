using MediatR;
using MediatRDemo.Models;
using MediatRDemo.Queries;
using MediatRDemo.Repositories;

namespace MediatRDemo.Handlers
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<List<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            //MyMethod();
            return _employeeRepository.GetAll();
        }

        private void MyMethod()
        {

        }
    }
}
