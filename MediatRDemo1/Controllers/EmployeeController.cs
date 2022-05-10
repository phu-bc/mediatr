using MediatRDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

        }
    }
}
