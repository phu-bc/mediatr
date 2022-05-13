using MediatR;
using MediatRDemo.Models;

namespace MediatRDemo.Commands
{
    public class AddEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
