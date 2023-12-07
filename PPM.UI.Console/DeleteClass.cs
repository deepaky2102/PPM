using PPM.Dal;
using PPM.Domain;     // Import the PPM.UI.Domain namespace to use classes from it.
using PPM.Model;      // Import the PPM.UI.Model namespace to use classes from it.

namespace PPM.UI.Console
{
    public class DeleteClass
    {
        readonly ConsoleInputs consoleInputs = new();
        readonly EmployeeMethods employeeMethods = new();
        readonly EmployeeProjectRelationMethod employeeProjectRelationMethod = new();
        readonly ProjectMethods projectMethods = new();
        readonly RoleMethods roleMethods = new();
        readonly EmployeeProjectRelationDal employeeProjectRelationDal = new();
        readonly ProjectDal projectDal = new();
        public void DeleteProject(List<ProjectClass> ListRetrieve)
        {
            long ProjectId = consoleInputs.ProjectId();

            // if (EmployeeProjectRelationMethod.EmpProRelList.Exists(project => project.ProjectId == ProjectId && project.Status == "Active"))
            if(employeeProjectRelationDal.EmployeeActiveInProject(ProjectId))
            {
                System.Console.WriteLine("Employee Present in Project, remove from the project first.");
            }
            else
            {
                // Find the project to remove based on the entered Project Id.
                // ProjectClass ProjectToRemove = ListRetrieve.Find(project => project.ProjectId == ProjectId)!;

                // if (ProjectToRemove != null)
                if(projectDal.ProjectExist(ProjectId))
                {
                    // projectMethods.DeleteObject(ProjectToRemove);
                    projectMethods.DeleteObject(ProjectId);
                    System.Console.WriteLine($" Project ID: {ProjectId} is removed from Project Record.");
                }
                else
                {
                    // If no match is found for the Project ID, display a message indicating that.
                    System.Console.WriteLine($"No match found for Project ID: {ProjectId}.");
                }
            }
        }

        public void DeleteRole(List<RoleClass> ListRetrieve)
        {
            long RoleId = consoleInputs.RoleId();

            // if (EmployeeProjectRelationMethod.EmpProRelList.Exists(role => role.RoleId == RoleId && role.Status == "Active"))
            if(employeeProjectRelationDal.EmployeeActiveAsRole(RoleId))
            {
                System.Console.WriteLine("An active employee with this role is assigned to the project. Please change the employee's role or remove them from the project first.");
            }
            else
            {
                // Find the role to remove based on the entered Role Id.
                RoleClass RoleToRemove = ListRetrieve.Find(Role => Role.RoleId == RoleId)!;

                if (RoleToRemove != null)
                {
                    // roleMethods.DeleteObject(RoleToRemove);
                    roleMethods.DeleteObject(RoleId);
                    System.Console.WriteLine($" Role ID: {RoleId} is removed from Role Record.");
                }
                else
                {
                    // If no match is found for the Role ID, display a message indicating that.
                    System.Console.WriteLine($"No match found for Role ID: {RoleId}.");
                }
            }
        }

        public void DeleteEmployee(List<EmployeeClass> ListRetrieve)
        {
            long EmployeeId = consoleInputs.EmployeeId();

            // if (EmployeeProjectRelationMethod.EmpProRelList.Exists(employee => employee.EmployeeId == EmployeeId && employee.Status == "Active"))
            if(employeeProjectRelationDal.EmployeeExistsInProject(EmployeeId))
            {
                System.Console.WriteLine("Employee Present in Project, remove from the project first.");
            }
            else
            {
                // Find the employee to remove based on the entered Employee Id.
                EmployeeClass EmployeeToRemove = ListRetrieve.Find(Employee => Employee.EmployeeId == EmployeeId)!;

                if (EmployeeToRemove != null)
                {
                    // employeeMethods.DeleteObject(EmployeeToRemove);
                    employeeMethods.DeleteObject(EmployeeId);
                    System.Console.WriteLine($" Employee ID: {EmployeeId} is removed from Employee Record.");
                }
                else
                {
                    // If no match is found for the Employee ID, display a message indicating that.
                    System.Console.WriteLine($"No match found for Employee ID: {EmployeeId}.");
                }
            }
        }

        public void DeleteEmployeeFromProject(List<EmployeeProjectRelationClass> ListRetrieve)
        {
            long Id = consoleInputs.Id();

            // Find the project details to remove based on the entered Id.
            EmployeeProjectRelationClass IdToRemove = ListRetrieve.Find(EPRM => EPRM.Id == Id)!;

            if (IdToRemove != null)
            {
                // Call a method to update the specified employee status in project details if they exist in the list.
                // employeeProjectRelationMethod.DeleteObject(IdToRemove);
                employeeProjectRelationMethod.DeleteObject(Id);
                System.Console.WriteLine($" ID: {Id} is removed from Employee Record.");
            }
            else
            {
                // If no match is found for the Role ID, display a message indicating that.
                System.Console.WriteLine($"No match found for ID: {Id}.");
            }
        }
    }
}