using MediatR;
using MediatRDemo.Commands;
using MediatRDemo.Models;
using MediatRDemo.Repositories;

namespace MediatRDemo.Handlers
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var newId = await _employeeRepository.Add(new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            });

            return newId;
        }
    }
}
