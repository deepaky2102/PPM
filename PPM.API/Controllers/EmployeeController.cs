using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using PPM.Domain;
using PPM.Model;

namespace PPM.API
{

    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        readonly EmployeeMethods employeeRepo = new();

        [HttpGet("GetAllObject/")]
        public IActionResult GetAllObject()
        {
            var Employees = employeeRepo!.GetAllObject();
            return Ok(Employees);
        }

        [HttpGet("GetObjectById/{id}")]
        public IActionResult GetObjectById(int id)
        {
            var Employee = employeeRepo!.GetObjectById(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }

        [HttpPost("{Create}")]
        public IActionResult AddNewObject(EmployeeClass employee)
        {
            if (EmployeeMethods.EmployeeList.Exists(p => p.EmployeeId == employee.EmployeeId))
            {
                return StatusCode(400, "Employee Id already exists.");
            }

            employeeRepo!.AddNewObject(employee);
            return Content("Employee Added Successfuly");
        }

        [HttpDelete("DeleteObject/{id}")]
        public IActionResult DeleteObject(int id)
        {
            var Employees = employeeRepo!.GetObjectById(id);

            if (Employees == null || Employees.Count == 0)
            {
                // return NotFound();
                // return new BadRequestResult();
                return StatusCode(400, "Employee Id does not exist");
            }
            else
            {
                employeeRepo.DeleteObject(id);
                return Content("Employee Deleted Successfully");
            }
        }
    }
}