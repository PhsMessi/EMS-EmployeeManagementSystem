using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using EmployeeManagementSystem.Models.Api;
namespace EmployeeManagementSystem.Controllers
{
    //[Route("Employee/[action]/{id?}")]
    
    public class EmployeeController : Controller
    {
        public readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        //display Create layout
        public IActionResult Create()
        {
            return View();
        }

        //display Tables
        public IActionResult Table()
        {
            var EmployeeList = _context.Employees.ToList();
            return View(EmployeeList);
        }


        [HttpPost]

        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Table");
            }

            return View(employee);
        }


        public IActionResult Update(int id)
        {
            var Employee = _context.Employees.Find(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        [HttpPost]
        public IActionResult Update(int id, Employee updateEmployee)
        {
            var Employee = _context.Employees.Find(id);
            if (Employee == null)
            {
                return NotFound();
            }

            Employee.EmployeeName = updateEmployee.EmployeeName;
            Employee.Phone = updateEmployee.Phone;
            Employee.Address = updateEmployee.Address;
            Employee.Birthday = updateEmployee.Birthday;
            Employee.Age = updateEmployee.Age;

            _context.SaveChanges();

            return RedirectToAction("Table");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Employee = _context.Employees.Find(id);

            if(Employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(Employee);
            _context.SaveChanges();

            return RedirectToAction("Table");
        }

    }
}
