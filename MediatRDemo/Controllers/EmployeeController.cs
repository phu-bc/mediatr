using AutoMapper;
using MediatRDemo.Models;
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
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRepository.GetAll();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeRepository.GetById(id);

            if(employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeRequest employee)
        {
            var newEmployee = _mapper.Map<Employee>(employee);
            var id = await _employeeRepository.Add(newEmployee);

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
