using MediatR;
using MediatRDemo.Models;

namespace MediatRDemo.Queries
{
    public class GetAllEmployeeQuery : IRequest<List<Employee>>, IRequest<Employee>
    {
    }
}
