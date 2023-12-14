using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using PPM.Domain;
using PPM.Model;

namespace PPM.API
{

    [Route("[controller]")]
    [ApiController]
    public class EmployeeProjectController : ControllerBase
    {

        readonly EmployeeProjectRelationMethod employeeProjectRelationMethod = new();

        [HttpGet("GetAllObject/")]
        public IActionResult GetAllObject()
        {
            var EmployeeProject = employeeProjectRelationMethod!.GetAllObject();
            return Ok(EmployeeProject);
        }

        [HttpGet("GetEmployeeProjectById/{id}")]
        public IActionResult GetEmployeeProjectById(int id)
        {
            var EmployeeProject = employeeProjectRelationMethod!.GetEmployeeProjectById(id);
            if (EmployeeProject == null)
            {
                return NotFound();
            }
            return Ok(EmployeeProject);
        }

        [HttpGet("GetObjectByProjectId/{id}")]
        public IActionResult GetObjectByProjectId(int id)
        {
            var EmployeeProject = employeeProjectRelationMethod!.GetObjectByProjectId(id);
            if (EmployeeProject == null)
            {
                return NotFound();
            }
            return Ok(EmployeeProject);
        }

        [HttpGet("GetObjectByEmployeeId/{id}")]
        public IActionResult GetObjectByEmployeeId(int id)
        {
            var EmployeeProject = employeeProjectRelationMethod!.GetObjectByEmployeeId(id);
            if (EmployeeProject == null)
            {
                return NotFound();
            }
            return Ok(EmployeeProject);
        }

        [HttpPost("{Create}")]
        public IActionResult AddNewObject(EmployeeProjectRelationClass employee)
        {
            if (EmployeeMethods.EmployeeList.Exists(p => p.EmployeeId == employee.EmployeeId))
            {
                return StatusCode(400, "Employee Id already exists.");
            }

            employeeProjectRelationMethod!.AddNewObject(employee);
            return Content("Employee Added Successfuly");
        }

        [HttpDelete("DeleteObject/{id}")]
        public IActionResult DeleteObject(int id)
        {
            var Employees = employeeProjectRelationMethod!.GetEmployeeProjectById(id);

            if (Employees == null || Employees.Count == 0)
            {
                // return NotFound();
                // return new BadRequestResult();
                return StatusCode(400, "Employee Id does not exist");
            }
            else
            {
                employeeProjectRelationMethod.DeleteObject(id);
                return Content("Employee Deleted Successfully");
            }
        }
    }
}