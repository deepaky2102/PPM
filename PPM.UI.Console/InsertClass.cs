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
        readonly EmployeeDal employeeDal = new();

        public void InsertProjectDetails()
        {
            try
            {
                ProjectClass IProjectObject = new ProjectClass(); // Initialize the required properties.

                // Set the ProjectId property of the IProjectObject by retrieving input from the ProjectIdExistCheck method.
                // IProjectObject.ProjectId = projectMethods.AssignPrimaryId();
                // if (IProjectObject.ProjectId == 0)
                // {
                //     throw new ArgumentException("Unable to process the task");
                // }

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

                while (true)
                {
                    System.Console.WriteLine("Do You want to add employee to project?");
                    System.Console.WriteLine("Enter 'Y' for 'Yes' or 'N' for 'No'.");
                    string input = System.Console.ReadLine()!;

                    if (input == "Y" || input == "y")
                    {
                        InsertEmployeeInProject(IProjectObject.ProjectId);
                    }
                    else if (input == "N" || input == "n")
                    {
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input");
                    }
                }
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

                // IRoleObject.RoleId = roleMethods.AssignPrimaryId();
                // if (IRoleObject.RoleId == 0)
                // {
                //     throw new ArgumentException("Unable to Process the task");
                // }

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

                // IEmployeeObject.EmployeeId = employeeMethods.AssignPrimaryId();
                // if (IEmployeeObject.EmployeeId == 0)
                // {
                //     throw new ArgumentException("Unable to Process the task");
                // }

                IEmployeeObject.FirstName = consoleInputs.FirstName()!;
                if (IEmployeeObject.FirstName ==  string.Empty || IEmployeeObject.FirstName == "0")
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
                // IEPRObject.Id = employeeProjectRelationMethod.AssignPrimaryId();
                // if (IEPRObject.Id == 0)
                // {
                //     throw new ArgumentException("Unable to Process the task");
                // }

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

                // Find the role based on EmployeeId
                // var role = EmployeeMethods.EmployeeList.Find(employee => employee.EmployeeId == IEPRObject.EmployeeId);
                long RoleId = employeeDal.EmployeeRole(IEPRObject.EmployeeId);
                if (RoleId != 0)
                {
                    IEPRObject.RoleId = RoleId;

                    employeeProjectRelationMethod.AddNewObject(IEPRObject);
                }
                else
                {
                    // Handle the case where role is null (employee not found)
                    throw new ArgumentException("Employee not found");
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
                EmployeeProjectRelationClass IEPRObject = new();       // Create an instance of the EmployeeProjectRelationClass to store role details.

                // IEPRObject.Id = employeeProjectRelationMethod.AssignPrimaryId();
                // if (IEPRObject.Id == 0)
                // {
                //     throw new ArgumentException("Unable to Process the task");
                // }

                IEPRObject.ProjectId = ProjectId;

                IEPRObject.EmployeeId = consoleInputs.EmployeeExistInProjectCheck(IEPRObject.ProjectId);
                if (IEPRObject.EmployeeId == 0)
                {
                    throw new ArgumentException("Unable to Process the task");
                }

                // Find the role based on EmployeeId
                // var role = EmployeeMethods.EmployeeList.Find(employee => employee.EmployeeId == IEPRObject.EmployeeId);
                long RoleId = employeeDal.EmployeeRole(IEPRObject.EmployeeId);
                if (RoleId != 0)
                {
                    IEPRObject.RoleId = RoleId;

                    employeeProjectRelationMethod.AddNewObject(IEPRObject);
                }
                else
                {
                    // Handle the case where role is null (employee not found)
                    throw new ArgumentException("Employee not found");
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