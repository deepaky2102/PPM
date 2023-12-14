using PPM.Dal;        // Import the PPM.UI.Dal namespace to use classes from it.
using PPM.Domain;     // Import the PPM.UI.Domain namespace to use classes from it.
using PPM.Model;      // Import the PPM.UI.Model namespace to use classes from it.

namespace PPM.UI.Console
{

    public class InsertClass
    {
        readonly ConsoleInputs consoleInputs = new();
        readonly EmployeeMethods employeeMethods = new();
        readonly EmployeeProjectRelationMethod employeeProjectRelationMethod = new();
        readonly ProjectMethods projectMethods = new();
        readonly RoleMethods roleMethods = new();

        public void InsertProjectDetails()
        {
            try
            {
                ProjectClass IProjectObject = new ProjectClass(); // Initialize the required properties.

                // Set the Name property of the IProjectObject by retrieving input from the ProjectName method.
                IProjectObject.Name = consoleInputs.ProjectName()!;
                if (IProjectObject.Name == string.Empty || IProjectObject.Name == "0")
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                while (true)  // Start an input loop to ensure a valid Begin Date is entered.
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter Project Begin Date:");

                    // Call the Date() method to prompt the user for a Project Begin Date and assign it to IProjectObject.StartDate.
                    IProjectObject.StartDate = consoleInputs.Date();

                    // Check if the entered StartDate is not the default (minimum) value.
                    if (IProjectObject.StartDate != DateTime.MinValue)
                    {
                        // If a valid StartDate is provided, exit the loop.
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter proper Date.");
                    }
                }

                while (true)  // Start an input loop to ensure a valid End Date is entered.
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter Project End Date:");

                    // Call the Date() method to prompt the user for a Project End Date and assign it to IProjectObject.EndDate.
                    IProjectObject.EndDate = consoleInputs.Date();

                    // Check if the entered StartDate is not the default (minimum) value.
                    if (IProjectObject.EndDate != DateTime.MinValue)
                    {
                        // Check if the Project End Date is earlier than the Project Begin Date.
                        if (IProjectObject.EndDate < IProjectObject.StartDate)
                        {
                            // Display an error message if condition is true.
                            System.Console.WriteLine();
                            System.Console.WriteLine("Project end date should be less than begin date ");
                        }
                        else
                        {
                            // If a valid EndDate is provided, exit the loop.
                            break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter proper Date.");
                    }
                }

                projectMethods.AddNewObject(IProjectObject);   // Add the new project to the list of project.
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void InsertRoleDetails()
        {
            try
            {
                RoleClass IRoleObject = new();       // Create an instance of the RoleClass to store role details.

                IRoleObject.Name = consoleInputs.RoleName()!;
                if (IRoleObject.Name == string.Empty || IRoleObject.Name == "0")
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                roleMethods.AddNewObject(IRoleObject);   // Add the new role to the list of Role.
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void InsertEmployeeDetails()
        {
            try
            {
                EmployeeClass IEmployeeObject = new();  // Create an instance of the EmployeeClass to store employee details.

                IEmployeeObject.FirstName = consoleInputs.FirstName()!;
                if (IEmployeeObject.FirstName == string.Empty || IEmployeeObject.FirstName == "0")
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                IEmployeeObject.LastName = consoleInputs.LastName()!;
                if (IEmployeeObject.LastName == string.Empty || IEmployeeObject.LastName == "0")
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                IEmployeeObject.Email = consoleInputs.EmailExistsCheck()!;
                if (IEmployeeObject.Email == string.Empty || IEmployeeObject.Email == "0")
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                IEmployeeObject.MobileNumber = consoleInputs.MobileNumberExistsCheck()!;
                if (IEmployeeObject.MobileNumber == string.Empty || IEmployeeObject.MobileNumber == "0")
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                IEmployeeObject.Address = consoleInputs.Address()!;
                if (IEmployeeObject.Address == string.Empty || IEmployeeObject.Address == "0")
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                IEmployeeObject.RoleId = consoleInputs.AddRoleIdToEmployeeIfExists();
                if (IEmployeeObject.RoleId == 0)
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                employeeMethods.AddNewObject(IEmployeeObject); // Add the new employee to the list of employees.
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void InsertEPRDetails()
        {
            EmployeeProjectRelationClass IEPRObject = new();       // Create an instance of the EmployeeProjectRelationClass to store role details.
            try
            {
                IEPRObject.ProjectId = consoleInputs.AddProjectIdToDetails(consoleInputs.ProjectId());
                if (IEPRObject.ProjectId == 0)
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                IEPRObject.EmployeeId = consoleInputs.EmployeeExistInProjectCheck(IEPRObject.ProjectId);
                if (IEPRObject.EmployeeId == 0)
                {
                    throw new ArgumentException("Unable to Process the task");
                }
                else
                {
                    employeeProjectRelationMethod.AddNewObject(IEPRObject);
                }
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void InsertEmployeeInProject(long ProjectId)
        {
            try
            {
                EmployeeProjectRelationClass IEPRObject = new()
                {
                    ProjectId = ProjectId
                };

                IEPRObject.EmployeeId = consoleInputs.EmployeeExistInProjectCheck(IEPRObject.ProjectId);
                if (IEPRObject.EmployeeId == 0)
                {
                    throw new ArgumentException("Unable to Process the task");
                }
                else
                {
                    employeeProjectRelationMethod.AddNewObject(IEPRObject);
                }
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }
    }
}