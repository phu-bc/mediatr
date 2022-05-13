using AutoMapper;
using MediatR;
using MediatRDemo.Commands;
using MediatRDemo.Models;
using MediatRDemo.Queries;
using MediatRDemo.Repositories;
using MediatRDemo.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediator _mediator;

        public EmployeeController(IEmployeeRepository employeeRepository,
            IMediator mediator)
        {
            _employeeRepository = employeeRepository;
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

            if(employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] AddEmployeeCommand addEmployeeCommand)
        {
            //var addEmployeeCommand = new AddEmployeeCommand
            //{
            //    FirstName = employee.FirstName,
            //    LastName = employee.LastName,
            //    Email = employee.Email
            //};
            var id = await _mediator.Send(addEmployeeCommand);

            //var newEmployee = new Employee
            //{
            //    FirstName = employee.FirstName,
            //    LastName = employee.LastName,
            //    Email = employee.Email
            //};
            //var id = await _employeeRepository.Add(newEmployee);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.Delete(id);

            return Ok();
        }
    }
}
