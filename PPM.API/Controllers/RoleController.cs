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

        [HttpGet("GetAllObject/")]
        public IActionResult GetAllObject()
        {
            var roles = roleRepo!.GetAllObject();
            return Ok(roles);
        }

        [HttpGet("GetObjectById/{id}")]
        public IActionResult GetObjectById(int id)
        {
            var role = roleRepo!.GetObjectById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost("{Create}")]
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

        [HttpDelete("DeleteObject/{id}")]
        public IActionResult DeleteObject(int id)
        {
            var roles = roleRepo!.GetObjectById(id);

            if (roles == null || roles.Count == 0)
            {
                // return NotFound();
                // return new BadRequestResult();
                return StatusCode(400, "Role Id does not exist");
            }
            else
            {
                roleRepo.DeleteObject(id);
                return Content("Role Deleted Successfully");
            }
        }
    }
}