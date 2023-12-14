using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using PPM.Domain;
using PPM.Model;

namespace PPM.API
{

    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        readonly ProjectMethods projectRepo = new();

        [HttpGet("GetAllObject/")]
        public IActionResult GetAllObject()
        {
            var Projects = projectRepo!.GetAllObject();
            return Ok(Projects);
        }

        [HttpGet("GetObjectById/{id}")]
        public IActionResult GetObjectById(int id)
        {
            var Project = projectRepo!.GetObjectById(id);
            if (Project == null)
            {
                return NotFound();
            }
            return Ok(Project);
        }

        [HttpPost("{Create}")]
        public IActionResult AddNewObject(ProjectClass project)
        {
            if (ProjectMethods.ProjectList.Exists(p => p.ProjectId == project.ProjectId))
            {
                return StatusCode(400, "Project Id already exists.");
            }

            if (!Regex.IsMatch(project.Name!, @"^[^\d]+$"))
            {
                return StatusCode(400, "Invalid Name");
            }

            projectRepo!.AddNewObject(project);
            return Content("Project Added Successfuly");
        }

        [HttpDelete("DeleteObject/{id}")]
        public IActionResult DeleteObject(int id)
        {
            var Projects = projectRepo!.GetObjectById(id);

            if (Projects == null || Projects.Count == 0)
            {
                // return NotFound();
                // return new BadRequestResult();
                return StatusCode(400, "Project Id does not exist");
            }
            else
            {
                projectRepo.DeleteObject(id);
                return Content("Project Deleted Successfully");
            }
        }
    }
}