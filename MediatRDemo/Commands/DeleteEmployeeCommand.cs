using MediatR;

namespace MediatRDemo.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }

        public DeleteEmployeeCommand(int id)
        {
            EmployeeId = id;
        }
    }
}
