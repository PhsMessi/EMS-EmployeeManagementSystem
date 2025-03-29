using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Models.Api;
namespace EmployeeManagementSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly EmployeeDbContext _context;

        public ValuesController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var allEmployee = _context.Employees.ToList();
            return Ok(allEmployee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployee employee)
        {
            var NewEmployee = new Employee
            {
                EmployeeName = employee.EmployeeName,
                EmployeeId = employee.EmployeeId,
                Phone = employee.Phone,
                Address = employee.Address,
                Birthday = employee.Birthday,
                Age = employee.Age,
            };

            _context.Employees.Add(NewEmployee);
            _context.SaveChanges();
            return Ok(NewEmployee);
        }

        [HttpPut("id")]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployee updateEmployee)
        {
            var Employee = _context.Employees.Find(id);

            if (Employee == null)
            {
                return BadRequest();
            }

            Employee.EmployeeName = updateEmployee.EmployeeName;
            Employee.Phone = updateEmployee.Phone;
            Employee.Address = updateEmployee.Address;
            Employee.Birthday = updateEmployee.Birthday;
            Employee.Age = updateEmployee.Age;

            _context.SaveChanges();

            return Ok(Employee);
        }

        [HttpDelete("id")]
        public IActionResult DeleteEmployee(int id)
        {
            var Employee = _context.Employees.Find(id);
            if(Employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(Employee);
            _context.SaveChanges();
            return Ok(Employee);
        }
    }
}
