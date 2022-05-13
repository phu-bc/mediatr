using MediatR;
using MediatRDemo.Commands;
using MediatRDemo.Models;
using MediatRDemo.Repositories;

namespace MediatRDemo.Handlers
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository,
            IMediator mediator)
        {
            _employeeRepository = employeeRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var newId = await _employeeRepository.Add(new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            });

            // Add User
            _userRepository.add(newUser);

            // Send Welcome email

            return newId;
        }
    }
}
