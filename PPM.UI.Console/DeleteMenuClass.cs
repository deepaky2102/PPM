using PPM.Domain;     // Import the PPM.UI.Domain namespace to use classes from it.
using PPM.Model;      // Import the PPM.UI.Model namespace to use classes from it.

namespace PPM.UI.Console
{
    public class DeleteMenuClass
    {
        readonly ConsoleInputs consoleInputs = new();
        readonly ConsoleOutputs consoleOutputs = new();
        readonly DeleteClass deleteClass = new();
        readonly EmployeeMethods employeeMethods = new();
        readonly EmployeeProjectRelationMethod employeeProjectRelationMethod = new();
        readonly ProjectMethods projectMethods = new();
        readonly RoleMethods roleMethods = new();

        public void DeleteProjectMenu()
        {
            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.

                // Start a loop to display the delete project menu and handle user input.
                do
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|--------------------------------------------|");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|               Delete Project               |");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|--------------------------------------------|");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|    1) Delete Project by Project Id         |");
                    System.Console.WriteLine("|    2) Delete Project by Project Name       |");
                    System.Console.WriteLine("|    3) Quit Delete Project Menu             |");
                    System.Console.WriteLine("|    4) Main Menu                            |");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|--------------------------------------------|");

                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Initialize a list to store retrieved project records.
                    var ListRetrieve = new List<ProjectClass>();

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {

                        case 1:     // Case 1: Delete Project by Project Id.
                            ListRetrieve = projectMethods.GetAllObject(); // Retrieve a list of Projects for display.
                            break;

                        case 2:// Case 2: Delete Project by project Name.
                            ListRetrieve = projectMethods.GetObjectByName(consoleInputs.ProjectName()!); // Retrieve projects with the specified project name.         
                            break;

                        case 3:     // Case 3: Quit Delete Project Menu.
                            System.Console.WriteLine("---- Quit Delete Project Menu ----");
                            break;

                        case 4:     // Case 4: Handle Main Menu.
                            MainMenuClass.MainMenuOption();
                            break;

                        default:     // Default case: Handle invalid menu options.
                            System.Console.WriteLine("---- Invalid Option ----");
                            break;
                    }

                    if (Option > 0 && Option < 3)
                    {
                        consoleOutputs.DisplayProject(ListRetrieve); // Display the list of projects.
                        if (ListRetrieve.Count > 0)
                        {
                            deleteClass.DeleteProject(ListRetrieve); // Perform project deletion.   
                        }
                    }
                    else if (Option == 0 || Option == 3)
                    {
                        break;
                    }
                } while (true);     // Continue the loop until the user selects option 3 (Quit).
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void DeleteRoleMenu()                                    //  Creating "ViewRoleMenu()" Method in "RoleClass" class.
        {
            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.

                // Start a loop to display the delete role menu and handle user input.
                do
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|-----------------------------------|");
                    System.Console.WriteLine("|                                   |");
                    System.Console.WriteLine("|           Delete Role             |");
                    System.Console.WriteLine("|                                   |");
                    System.Console.WriteLine("|-----------------------------------|");
                    System.Console.WriteLine("|                                   |");
                    System.Console.WriteLine("|    1) Delete Role by Role Id      |");
                    System.Console.WriteLine("|    2) Delete Role by Role Name    |");
                    System.Console.WriteLine("|    3) Quit Delete Role Menu       |");
                    System.Console.WriteLine("|    4) Main Menu                   |");
                    System.Console.WriteLine("|                                   |");
                    System.Console.WriteLine("|-----------------------------------|");

                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Initialize a list to store retrieved role records.
                    var ListRetrieve = new List<RoleClass>();

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {
                        case 1:     // Case 1: Delete Role by Role Id.
                            ListRetrieve = roleMethods.GetAllObject(); // Retrieve a list of Roles for display
                            break;

                        case 2:// Case 2: Delete Role by role Name.
                            ListRetrieve = roleMethods.GetObjectByName(consoleInputs.RoleName()!);
                            break;

                        case 3:     // Case 3: Quit Delete Role Menu.
                            System.Console.WriteLine("---- Quit Delete Role Menu ----");
                            break;

                        case 4:     // Case 4: Handle Main Menu.
                            MainMenuClass.MainMenuOption();
                            break;

                        default:     // Default case: Handle invalid menu options.
                            System.Console.WriteLine("---- Invalid Option ----");
                            break;
                    }

                    if (Option > 0 && Option < 3)
                    {
                        consoleOutputs.DisplayRole(ListRetrieve); // Display the list of roles.
                        if (ListRetrieve.Count > 0)
                        {
                            deleteClass.DeleteRole(ListRetrieve); // Perform role deletion.                            
                        }
                    }
                    else if (Option == 0 || Option == 3)
                    {
                        break;
                    }
                } while (true);     // Continue the loop until the user selects option 3 (Quit).
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void DeleteEmployeeMenu()
        {
            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.

                // Start a loop to display the delete employee menu and handle user input.
                do
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|--------------------------------------------------------|");
                    System.Console.WriteLine("|                                                        |");
                    System.Console.WriteLine("|                    Delete Employee                     |");
                    System.Console.WriteLine("|                                                        |");
                    System.Console.WriteLine("|--------------------------------------------------------|");
                    System.Console.WriteLine("|                                                        |");
                    System.Console.WriteLine("|    1) Delete Employee by Employee Id                   |");
                    System.Console.WriteLine("|    2) Delete Employee by Employee First Name           |");
                    System.Console.WriteLine("|    3) Delete Employee by Employee Last Name            |");
                    System.Console.WriteLine("|    4) Delete Employee by Employee First and Last Name  |");
                    System.Console.WriteLine("|    5) Quit Delete Employee Menu                        |");
                    System.Console.WriteLine("|    6) Return to Main Menu                              |");
                    System.Console.WriteLine("|                                                        |");
                    System.Console.WriteLine("|--------------------------------------------------------|");

                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Initialize a list to store retrieved employee records.
                    var ListRetrieve = new List<EmployeeClass>();

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {

                        case 1:     // Case 1: Delete Employee by Employee Id.
                            ListRetrieve = employeeMethods.GetAllObject(); // Retrieve a list of employees for display.
                            break;

                        case 2:// Case 2: Delete Employee by Employee First Name.
                            ListRetrieve = employeeMethods.GetObjectByFirstName(consoleInputs.FirstName()!); // Retrieve employees with the specified first name.
                            break;

                        case 3:     // Case 3: Delete Employee by Employee Last Name.
                            ListRetrieve = employeeMethods.GetObjectByLastName(consoleInputs.LastName()!);  // Retrieve employees with the specified last name.
                            break;

                        case 4:     // Case 4: Delete Employee by Employee Full Name.
                            // Retrieve employees with the specified first and last name.
                            ListRetrieve = employeeMethods.GetObjectByFullName(consoleInputs.FirstName()!, consoleInputs.LastName()!);
                            break;

                        case 5:     // Case 5: Quit Delete Employee Menu.
                            System.Console.WriteLine("---- Quit Delete Employee Menu ----");
                            break;

                        case 6:     // Case 6: Handle Main Menu.
                            MainMenuClass.MainMenuOption();
                            break;

                        default:     // Default case: Handle invalid menu options.
                            System.Console.WriteLine("---- Invalid Option ----");
                            break;
                    }
                    if (Option > 0 && Option < 5)
                    {
                        consoleOutputs.DisplayEmployee(ListRetrieve); // Display the list of employees.
                        if (ListRetrieve.Count > 0)
                        {
                            deleteClass.DeleteEmployee(ListRetrieve); // Perform employee deletion.
                        }
                    }
                    else if (Option == 0 || Option == 5)
                    {
                        break;
                    }
                } while (true);     // Continue the loop until the user selects option 5 (Quit).
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void DeleteEmployeeFromProjectMenu()
        {
            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.

                // Start a loop to display the delete role menu and handle user input.
                do
                {
                    System.Console.WriteLine("|-------------------------------------------------|");
                    System.Console.WriteLine("|                                                 |");
                    System.Console.WriteLine("|         Delete Employee From Project Menu       |");
                    System.Console.WriteLine("|                                                 |");
                    System.Console.WriteLine("|-------------------------------------------------|");
                    System.Console.WriteLine("|                                                 |");
                    System.Console.WriteLine("|    1) Using Id.                                 |");
                    System.Console.WriteLine("|    2) Using Employee Id.                        |");
                    System.Console.WriteLine("|    3) Using Project Id                          |");
                    System.Console.WriteLine("|    4) Using Employee Id and Project Id          |");
                    System.Console.WriteLine("|    5) Quit Delete Employee From Project Menu    |");
                    System.Console.WriteLine("|    6) Main Menu                                 |");
                    System.Console.WriteLine("|                                                 |");
                    System.Console.WriteLine("|-------------------------------------------------|");

                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Initialize a list to store retrieved project details records.
                    var ListRetrieve = new List<EmployeeProjectRelationClass>();

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {

                        case 1:     // Case 1: Delete Project Details by EPR Id.
                            ListRetrieve = employeeProjectRelationMethod.GetAllObject(); // Retrieve a list of Project Details for display.
                            break;

                        case 2:     // Case 2: Delete Project Details by Project Id.
                            // Retrieve project details  records by ProjectId and store them in the ListRetrieve variable.
                            ListRetrieve = employeeProjectRelationMethod.GetObjectByProjectId(consoleInputs.ProjectId());
                            break;

                        case 3:     // Case 3: Delete Project Details by Employee Id.
                            // Retrieve project details records by EmployeeId and store them in the ListRetrieve variable.
                            ListRetrieve = employeeProjectRelationMethod.GetObjectByEmployeeId(consoleInputs.EmployeeId());
                            break;

                        case 4:
                            // Retrieve project details records by Project Id and EmployeeId and store them in the ListRetrieve variable.
                            ListRetrieve = employeeProjectRelationMethod.GetObjectByProjectIdAndEmployeeId(consoleInputs.ProjectId(), consoleInputs.EmployeeId());


                            break;

                        case 5:     // Case 5: Quit Delete Project Details Menu
                            System.Console.WriteLine("---- Quit Delete Project Details Menu ----");
                            break;

                        case 6:     // Case 6: Handle Main Menu.
                            MainMenuClass.MainMenuOption();
                            break;

                        default:     // Case Default: Handle invalid Delete Project Details menu options.
                            System.Console.WriteLine("---- Invalid Delete Project Details Menu Option Input ----");
                            break;
                    }

                    if (Option > 0 && Option < 5)
                    {
                        // Display the retrieved project details records using the DisplayEmployeeInProject function.
                        consoleOutputs.DisplayEmployeeInProject(ListRetrieve);

                        if (ListRetrieve.Count > 0)
                        {
                            // Perform Project details deletion.
                            deleteClass.DeleteEmployeeFromProject(ListRetrieve);   
                        }
                    }
                    else if (Option == 0 || Option == 5)
                    {
                        break;
                    }
                } while (true);     // Continue the loop until the user selects option 5 (Quit).
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }
    }
}