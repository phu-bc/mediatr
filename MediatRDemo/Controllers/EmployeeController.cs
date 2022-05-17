using MediatR;
using MediatRDemo.Commands;
using MediatRDemo.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var getAllEmployeeQuery = new GetAllEmployeeQuery();
            var employees = await _mediator.Send(getAllEmployeeQuery);

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getEmployeeByIdQuery = new GetEmployeByIdQuery
            {
                EmployeeId = id
            };

            var employee = await _mediator.Send(getEmployeeByIdQuery);

            return Ok(employee);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] AddEmployeeCommand addEmployeeCommand)
        {
            var id = await _mediator.Send(addEmployeeCommand);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand(id);
            await _mediator.Send(deleteEmployeeCommand);

            return Ok();
        }
    }
}
