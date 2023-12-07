using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using PPM.Domain;
using PPM.Model;

namespace PPM.API
{

    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly RoleMethods roleRepo = new();
        
        [HttpGet]
        public IActionResult GetAllObject()
        {
            var roles = roleRepo!.GetAllObject();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetObjectById(int id)
        {
            var role = roleRepo!.GetObjectById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost("{create}")]
        public IActionResult AddNewObject(RoleClass role)
        {
            if (RoleMethods.RoleList.Exists(p => p.RoleId == role.RoleId))
            {
                return StatusCode(400, "Role Id already exists.");
            }

            if (!Regex.IsMatch(role.Name!, @"^[^\d]+$"))
            {
                return StatusCode(400, "Invalid Name");
            }

            roleRepo!.AddNewObject(role);
            return Content("Role Added Successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteObject(int id)
        {
            var roles = roleRepo!.GetObjectById(id); // This returns a list
            if (roles == null || roles.Count == 0)
            {
                return NotFound();
            }

            // Assuming you want to delete the first role in the list
            var role = roles[0];

            if (!RoleMethods.RoleList.Exists(p => p.RoleId == role.RoleId))
            {
                return StatusCode(400, "Role Id does not exist");
            }
            roleRepo.DeleteObject(role.RoleId);
            return Content("Role Deleted Successfully");
        }
    }
}