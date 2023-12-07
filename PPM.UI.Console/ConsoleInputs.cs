using System.Globalization;
using PPM.Dal;
using PPM.Domain;     // Import the PPM.UI.Domain namespace to use classes from it.
using PPM.Model;

namespace PPM.UI.Console
{
    public class ConsoleInputs
    {
        readonly ProjectMethods projectMethods = new();
        readonly ProjectDal projectDal = new();
        readonly RoleDal roleDal = new();
        readonly EmployeeDal employeeDal = new();
        readonly EmployeeProjectRelationDal employeeProjectRelationDal = new();

        public int Option()
        {
            try
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter the Menu Option : (Option in Numeric Only)");
                // Read user input from the console for the menu option, parse it as an integer, and check if it's not a valid positive integer.
                if (!int.TryParse(System.Console.ReadLine(), out int Option) || Option < 0)
                {
                    // Handle invalid option input with an exception.
                    throw new ArgumentException("Option Id is Positive Integers Only");
                }
                else if (Option > 0)
                {
                    return Option;
                }
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
            return 0;
        }

        public long Id()
        {
            try
            {
                while (true)  // Start an input loop to ensure a valid Id is entered.
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter Id:");

                    // Read user input for Id, parse it as a long, and check if it's a valid positive integer.
                    if (!long.TryParse(System.Console.ReadLine(), out long Id) || Id < 0)
                    {
                        // If the input is not a valid positive integer, raise an exception.
                        throw new ArgumentException(" Id should be a integer value ");
                    }
                    else if (Id > 0)
                    {
                        // If there's no existing project details with the same Id, set it for the current project details object.
                        return Id;
                    }
                }
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
                System.Console.WriteLine();
            }
            return 0;
        }

        public long ProjectId()
        {
            try
            {
                while (true)     // Start a loop to repeatedly prompt the user for an project ID until valid input is provided.
                {
                    System.Console.WriteLine($"Enter Project Id:");

                    // Read the user's input, attempt to parse it as a long integer, and check if it's a positive value.
                    if (!long.TryParse(System.Console.ReadLine(), out long ProjectId) || ProjectId < 0)
                    {
                        // Handle the case where the input is not a valid positive integer and raise an exception.
                        throw new ArgumentException(" Project Id is Positive Integer Only ");
                    }
                    else if (ProjectId == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return ProjectId;   // If valid input is provided, return ProjectId and exit the loop.
                    }
                }
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
                return 0;
            }
        }

        public long AddProjectIdToDetails(long ProjectId)
        {
            try
            {
                // if (ProjectMethods.ProjectList.Exists(project => project.ProjectId == ProjectId))
                if (projectDal.ProjectExist(ProjectId))
                {
                    return ProjectId;
                }
                else
                {
                    throw new ArgumentException("Project Does not Exist");
                }
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
                return 0;
            }
        }


        public long RoleId()
        {
            try
            {
                while (true)     // Start a loop to repeatedly prompt the user for an role ID until valid input is provided.
                {
                    System.Console.WriteLine($"Enter Role Id:");

                    // Read the user's input, attempt to parse it as a long integer, and check if it's a positive value.
                    if (!long.TryParse(System.Console.ReadLine(), out long RoleId) || RoleId < 0)
                    {
                        // Handle the case where the input is not a valid positive integer and raise an exception.
                        throw new ArgumentException(" Role Id is Positive Integer Only ");
                    }
                    else if (RoleId == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return RoleId;      // If valid input is provided, exit the loop.
                    }
                }
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
                return 0;
            }
        }

        public long AddRoleIdToEmployeeIfExists()
        {
            ConsoleInputs consoleInputs = new();
            try
            {
                while (true)    // Start an input loop to ensure a valid Role Id is entered.
                {
                    System.Console.WriteLine();
                    long RoleId = consoleInputs.RoleId();

                    // RoleClass existingRole = RoleMethods.RoleList!.Find(role => role.RoleId == RoleId)!;
                    // if (existingRole != null)
                    if (roleDal.RoleExist(RoleId))
                    {
                        return RoleId;
                    }
                    else
                    {
                        // If a matching RoleId is not found, display an error message.
                        System.Console.WriteLine("--------- Role Id does not Exists ---------");
                    }
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
                return 0;
            }
        }

        public long EmployeeId()
        {
            try
            {
                while (true)  // Start an input loop to ensure a valid Employee Id is entered.
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter Employee Id:");

                    // Read user input for Employee Id, parse it as a long, and check if it's a valid positive integer.
                    if (!long.TryParse(System.Console.ReadLine(), out long EmployeeId) || EmployeeId < 0)
                    {
                        // If the input is not a valid positive integer, raise an exception.
                        throw new ArgumentException("Employee Id should be a positive integer value.");
                    }
                    else if (EmployeeId == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return EmployeeId;  // If valid input is provided, exit the loop.
                    }
                }
            }
            catch (ArgumentException exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
                return 0;
            }
        }

        public long EmployeeExistInProjectCheck(long ProjectId)
        {
            ConsoleInputs consoleInputs = new();
            try
            {
                while (true)  // Start an input loop to ensure a valid Employee Id is not already present in Project.
                {
                    long EmployeeId = consoleInputs.EmployeeId();

                    // Check if an employee with the same EmployeeId already exists in the employee list.
                    // if (EmployeeMethods.EmployeeList.Exists(employee => employee.EmployeeId == EmployeeId))
                    if (employeeDal.EmployeeExist(EmployeeId))
                    {
                        // if (EmployeeProjectRelationMethod.EmpProRelList.Exists(project => project.ProjectId == ProjectId && project.EmployeeId == EmployeeId && project.Status == "Active"))
                        if (employeeProjectRelationDal.EmployeeExistsInProject(ProjectId, EmployeeId))
                        {
                            // If a matching EmployeeId is already present, display an error message.
                            System.Console.WriteLine("--------- Employee Id already Exists ---------");
                        }
                        else
                        {
                            // If there is no existing employee with the same EmployeeId, set it for the current employee object.
                            return EmployeeId;
                        }
                    }
                    else
                    {
                        // If a matching EmployeeId is not found, display an error message.
                        System.Console.WriteLine("--------- Employee Id Does Not Exists ---------");
                    }
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
                return 0;
            }
        }

        public string? ProjectName()
        {
            try
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter Project Name:");
                string ProjectName = System.Console.ReadLine()!; // Read the user's input as a string, representing the Project name.
                if (CommonMethodClass.IsValidString(ProjectName) || int.Parse(ProjectName) != 0)
                {
                    return ProjectName ?? string.Empty;
                }
                else if (int.Parse(ProjectName) == 0)
                {
                    return "0";
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
            return string.Empty;
        }

        public string? RoleName()
        {
            try
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter Role Name:");
                string RoleName = System.Console.ReadLine()!; // Read the user's input as a string, representing the Role name.
                if (CommonMethodClass.IsValidString(RoleName) || int.Parse(RoleName) != 0)
                {
                    return RoleName ?? string.Empty;
                }
                else if (int.Parse(RoleName) == 0)
                {
                    return "0";
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
            return string.Empty;
        }

        public string? FirstName()
        {
            try
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter First Name:");
                string FirstName = System.Console.ReadLine()!; // Read the user's input as a string, representing the first name.
                if (CommonMethodClass.IsValidString(FirstName) || int.Parse(FirstName) != 0)
                {
                    return FirstName ?? string.Empty;
                }
                else if (int.Parse(FirstName) == 0)
                {
                    return "0";
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
            return string.Empty;
        }

        public string? LastName()
        {
            try
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter Last Name:");
                string LastName = System.Console.ReadLine()!; // Read the user's input as a string, representing the Last name.
                if (CommonMethodClass.IsValidString(LastName) || int.Parse(LastName) != 0)
                {
                    return LastName ?? string.Empty;
                }
                else if (int.Parse(LastName) == 0)
                {
                    return "0";
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
            return string.Empty;
        }

        public string? Email()
        {
            try
            {
                while (true) // Start an input loop to ensure a valid Email address is entered.
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter Email Id:");
                    String Email = System.Console.ReadLine()!; // Read the user's input as a string, representing the Email Address.
                    if (CommonMethodClass.IsValidEmail(Email) || int.Parse(Email) != 0)
                    {
                        return Email ?? string.Empty;
                    }
                    else if (int.Parse(Email) == 0)
                    {
                        return "0";
                    }
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
            return string.Empty;
        }

        public string? EmailExistsCheck()
        {
            ConsoleInputs consoleInputs = new();
            try
            {
                while (true)
                {
                    string Email = consoleInputs.Email()!;
                    // Check if the Email Id already exists in the list of employees.
                    // if (EmployeeMethods.EmployeeList.Exists(Employee => Employee.Email == Email))
                    if (employeeDal.EmailExist(Email))
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("--------- Email Id Already Exists ---------");
                    }
                    else
                    {
                        // If the Email Id is valid and doesn't exist in the list, exit the loop.
                        return Email;
                    }
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
                return null;
            }
        }

        public string? MobileNumber()
        {
            try
            {
                while (true) // Start an input loop to ensure a valid Mobile Number is entered.
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter Mobile Number:");
                    string mobileNumberInput = System.Console.ReadLine()!; // Read and store the Mobile Number input.

                    if (string.IsNullOrWhiteSpace(mobileNumberInput))
                    {
                        System.Console.WriteLine("Mobile Number cannot be empty. Please try again.");
                        continue;
                    }

                    if (CommonMethodClass.IsValidMobileNumber(mobileNumberInput))
                    {
                        return mobileNumberInput;
                    }
                    else if (mobileNumberInput == "0")
                    {
                        return "0";
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid Mobile Number format. Please try again.");
                    }
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }

            return string.Empty;
        }

        public string? MobileNumberExistsCheck()
        {
            ConsoleInputs consoleInputs = new();
            try
            {
                while (true)
                {
                    string MobileNumber = consoleInputs.MobileNumber()!;

                    // Check if the Mobile Number already exists in the list of employees.
                    // if (EmployeeMethods.EmployeeList.Exists(Employee => Employee.MobileNumber == MobileNumber))
                    if (employeeDal.MobileNumberExist(MobileNumber))
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("--------- Mobile Number Already Exists ---------");
                    }
                    else
                    {
                        // If the Mobile Number is valid and doesn't exist in the list, exit the loop.
                        return MobileNumber;
                    }
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
                return null;
            }
        }

        public string? Address()
        {
            try
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter Address");
                string Address = System.Console.ReadLine()!; // Read the user's input as a string, representing the Address.
                if (CommonMethodClass.IsValidString(Address) || int.Parse(Address) != 0)
                {
                    return Address ?? string.Empty;
                }
                else if (int.Parse(Address) == 0)
                {
                    return "0";
                }
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
            return string.Empty;
        }

        public DateTime Date()
        {
            System.Console.WriteLine("Enter Year:");
            if (!int.TryParse(System.Console.ReadLine(), out int Year) || Year < 0)
            {
                System.Console.WriteLine("Year should be a positive integer.");
                return DateTime.MinValue;
            }

            System.Console.WriteLine("Enter Month:");
            if (!int.TryParse(System.Console.ReadLine(), out int Month) || Month < 1 || Month > 12)
            {
                System.Console.WriteLine("Month should be an integer between 1 and 12.");
                return DateTime.MinValue;
            }

            int selectedDayArr = projectMethods.InsertDate(Year, Month);

            System.Console.WriteLine("Enter Day:");
            if (!int.TryParse(System.Console.ReadLine(), out int Day) || Day < 1 || Day > selectedDayArr)
            {
                System.Console.WriteLine($"Day should be a positive integer. In {Month} Month there are {selectedDayArr} days only.");
                return DateTime.MinValue;
            }
            else
            {
                string formattedDate = $"{Year}-{Month:D2}-{Day:D2}";
                return DateTime.Parse(formattedDate, CultureInfo.InvariantCulture);
            }
        }
    }
}