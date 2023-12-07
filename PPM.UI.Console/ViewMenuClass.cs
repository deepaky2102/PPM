using PPM.Domain;     // Import the PPM.UI.Domain namespace to use classes from it.
using PPM.Model;      // Import the PPM.UI.Model namespace to use classes from it.

namespace PPM.UI.Console
{
    public class ViewMenuClass
    {
        readonly ConsoleInputs consoleInputs = new();
        readonly ConsoleOutputs consoleOutputs = new();
        readonly EmployeeMethods employeeMethods = new();
        readonly EmployeeProjectRelationMethod employeeProjectRelationMethod = new();
        readonly ProjectMethods projectMethods = new();
        readonly RoleMethods roleMethods = new();

        public void ViewProjectMenu()
        {
            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.

                // Start a loop to display the view project menu and handle user input.
                do
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|--------------------------------------------|");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|               View Project                 |");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|--------------------------------------------|");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|    1) View All Project                     |");
                    System.Console.WriteLine("|    2) View Project by Project Id           |");
                    System.Console.WriteLine("|    3) View Project by Project Name         |");
                    System.Console.WriteLine("|    4) Quit View Project Menu               |");
                    System.Console.WriteLine("|    5) Main Menu                            |");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|--------------------------------------------|");

                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Initialize a list to store retrieved project records.
                    var ListRetrieve = new List<ProjectClass>();

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {
                        case 1:     // Case 1: View All Project
                            // Retrieve all project records and store them in the ListRetrieve variable.
                            ListRetrieve = projectMethods.GetAllObject();
                            break;

                        case 2:     // Case 2: View Project by Project I
                            // Retrieve project records by their unique ProjectId and store them in the ListRetrieve variable.
                            ListRetrieve = projectMethods.GetObjectById(consoleInputs.ProjectId());
                            break;

                        case 3:     // Case 3: View Project by Project  Name
                            // Retrieve project records by matching the provided name and store them in ListRetrieve.
                            ListRetrieve = projectMethods.GetObjectByName(consoleInputs.ProjectName()!);
                            break;

                        case 4:     // Case 6: Quit View project Menu
                            System.Console.WriteLine("---- Quit View Project Menu ----");
                            break;

                        case 5:     // Case 5: Handle Main Menu.
                            MainMenuClass.MainMenuOption();
                            break;

                        default:     // Case Default: Handle invalid menu options.
                            System.Console.WriteLine("---- Invalid Option ----");
                            break;
                    }

                    if (Option > 0 && Option < 4)
                    {
                        // Display the retrieved project records using the DisplayProject function.
                        consoleOutputs.DisplayProject(ListRetrieve);
                    }
                    else if (Option == 0 || Option == 4)
                    {
                        break;
                    }
                } while (true);     // Continue the loop until the user selects option 4 (Quit).
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void ViewRoleMenu()
        {
            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.

                // Start a loop to display the view role menu and handle user input.
                do
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|---------------------------------|");
                    System.Console.WriteLine("|                                 |");
                    System.Console.WriteLine("|           View Role             |");
                    System.Console.WriteLine("|                                 |");
                    System.Console.WriteLine("|---------------------------------|");
                    System.Console.WriteLine("|                                 |");
                    System.Console.WriteLine("|    1) View All Role             |");
                    System.Console.WriteLine("|    2) View Role by Role Id      |");
                    System.Console.WriteLine("|    3) View Role by Role Name    |");
                    System.Console.WriteLine("|    4) Quit View Role Menu       |");
                    System.Console.WriteLine("|    5) Main Menu                 |");
                    System.Console.WriteLine("|                                 |");
                    System.Console.WriteLine("|---------------------------------|");

                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Initialize a list to store retrieved role records.
                    var ListRetrieve = new List<RoleClass>();

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {
                        case 1:     // Case 1: View All Role
                            // Retrieve all role records and store them in the ListRetrieve variable.
                            ListRetrieve = roleMethods.GetAllObject();
                            break;

                        case 2:     // Case 2: View Role by Role Id
                            // Retrieve role records by their unique RoleId and store them in the ListRetrieve variable.
                            ListRetrieve = roleMethods.GetObjectById(consoleInputs.RoleId());
                            break;

                        case 3:     // Case 3: View Role by Role  Name
                            // Retrieve role records by matching the provided name and store them in ListRetrieve.
                            ListRetrieve = roleMethods.GetObjectByName(consoleInputs.RoleName()!);
                            break;

                        case 4:     // Case 4: Quit View role Menu
                            System.Console.WriteLine("---- Quit View role Menu ----");
                            break;

                        case 5:     // Case 5: Handle Main Menu.
                            MainMenuClass.MainMenuOption();
                            break;

                        default:     // Case Default: Handle invalid menu options.
                            System.Console.WriteLine("---- Invalid View Role Menu Option Input ----");
                            break;
                    }

                    if (Option > 0 && Option < 4)
                    {
                        // Display the retrieved role records using the DisplayRole function.
                        consoleOutputs.DisplayRole(ListRetrieve);
                    }
                    else if (Option == 0 || Option == 4)
                    {
                        break;
                    }
                } while (true);     // Continue the loop until the user selects option 4 (Quit).
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void ViewEmployeeMenu()
        {
            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.

                // Start a loop to display the view employee menu and handle user input.
                do
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|--------------------------------------------------------|");
                    System.Console.WriteLine("|                                                        |");
                    System.Console.WriteLine("|                      View Employee                     |");
                    System.Console.WriteLine("|                                                        |");
                    System.Console.WriteLine("|--------------------------------------------------------|");
                    System.Console.WriteLine("|                                                        |");
                    System.Console.WriteLine("|    1) View All Employee                                |");
                    System.Console.WriteLine("|    2) View Employee by Employee Id                     |");
                    System.Console.WriteLine("|    3) View Employee by Employee First Name             |");
                    System.Console.WriteLine("|    4) View Employee by Employee Last Name              |");
                    System.Console.WriteLine("|    5) View Employee by Employee First and Last Name    |");
                    System.Console.WriteLine("|    6) Quit View Employee Menu                          |");
                    System.Console.WriteLine("|    7) Return to Main Menu                              |");
                    System.Console.WriteLine("|                                                        |");
                    System.Console.WriteLine("|--------------------------------------------------------|");

                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Initialize a list to store retrieved employee records.
                    var ListRetrieve = new List<EmployeeClass>();

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {
                        case 1:     // Case 1: View All Employee
                            // Retrieve all employee records and store them in the ListRetrieve variable.
                            ListRetrieve = employeeMethods.GetAllObject();
                            break;

                        case 2:     // Case 2: View Employee by Employee Id
                            // Retrieve employee records by their unique EmployeeId and store them in the ListRetrieve variable.
                            ListRetrieve = employeeMethods.GetObjectById(consoleInputs.EmployeeId());
                            break;

                        case 3:     // Case 3: View Employee by Employee First Name
                            // Retrieve employee records by matching the provided first name and store them in ListRetrieve.
                            ListRetrieve = employeeMethods.GetObjectByFirstName(consoleInputs.FirstName()!);
                            break;

                        case 4:     // Case 4: View Employee by Employee Last Name
                            // Retrieve employee records by matching the provided last name and store them in ListRetrieve.
                            ListRetrieve = employeeMethods.GetObjectByLastName(consoleInputs.LastName()!);
                            break;

                        case 5:     // Case 5: View Employee by Employee First and Last Name
                            // Retrieve employee records by matching the provided first and last names and store them in ListRetrieve.
                            ListRetrieve = employeeMethods.GetObjectByFullName(consoleInputs.FirstName()!, consoleInputs.LastName()!);
                            break;

                        case 6:     // Case 6: Quit View Employee Menu
                            System.Console.WriteLine("---- Quit View Employee Menu ----");
                            break;

                        case 7:     // Case 7: Handle Main Menu.
                            MainMenuClass.MainMenuOption();
                            break;

                        default:     // Case Default: Handle invalid menu options.
                            System.Console.WriteLine("---- Invalid Option ----");
                            break;
                    }

                    if (Option > 0 && Option < 6)
                    {
                        // Display the retrieved employee records using the DisplayEmployee function.
                        consoleOutputs.DisplayEmployee(ListRetrieve);
                    }
                    else if (Option == 0 || Option == 6)
                    {
                        break;
                    }
                } while (true);     // Continue the loop until the user selects option 6 (Quit).
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }

        public void ViewProjectDetailsMenu()
        {
            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.

                // Start a loop to display the view role menu and handle user input.
                do
                {
                    System.Console.WriteLine("|-----------------------------------------------|");
                    System.Console.WriteLine("|                                               |");
                    System.Console.WriteLine("|            View Project Details Menu          |");
                    System.Console.WriteLine("|                                               |");
                    System.Console.WriteLine("|-----------------------------------------------|");
                    System.Console.WriteLine("|                                               |");
                    System.Console.WriteLine("|    1) View All Data                           |");
                    System.Console.WriteLine("|    2) View By Project Id                      |");
                    System.Console.WriteLine("|    3) View By Employee Id                     |");
                    System.Console.WriteLine("|    4) View By Employee Id and Project Id      |");
                    System.Console.WriteLine("|    5) Quit View Employee From Project Menu    |");
                    System.Console.WriteLine("|    6) Main Menu                               |");
                    System.Console.WriteLine("|                                               |");
                    System.Console.WriteLine("|-----------------------------------------------|");

                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Initialize a list to store retrieved project details records.                    
                    var ListRetrieve = new List<EmployeeProjectRelationClass>();

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {
                        case 1:     // Case 1: View All Project Details
                            // Retrieve all Project details records and store them in the ListRetrieve variable.
                            ListRetrieve = employeeProjectRelationMethod.GetAllObject();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
                            break;

                        case 2:     // Case 2: View project details by using Project Id
                            // Retrieve project details  records by their unique ProjectId and store them in the ListRetrieve variable.
                            ListRetrieve = employeeProjectRelationMethod.GetObjectByProjectId(consoleInputs.ProjectId());
                            break;

                        case 3:     // Case 3: View project details by using Employee Id
                            // Retrieve project details records by EmployeeId and store them in the ListRetrieve variable.
                            ListRetrieve = employeeProjectRelationMethod.GetObjectByEmployeeId(consoleInputs.EmployeeId());
                            break;

                        case 4:     // Case 4: View project details by using Project Id and Employee Id
                            // Retrieve project details records by Project Id and EmployeeId and store them in the ListRetrieve variable.
                            ListRetrieve = employeeProjectRelationMethod.GetObjectByProjectIdAndEmployeeId(consoleInputs.ProjectId(), consoleInputs.EmployeeId());
                            break;

                        case 5:     // Case 5: Quit View role Menu
                            System.Console.WriteLine("---- Quit View Project Details Menu ----");
                            break;

                        case 6:     // Case 6: Handle Main Menu.
                            MainMenuClass.MainMenuOption();
                            break;

                        default:     // Case Default: Handle invalid menu options.
                            System.Console.WriteLine("---- Invalid View Project Details Menu Option Input ----");
                            break;
                    }

                    if (Option > 0 && Option < 5)
                    {
                        // Display the retrieved Project details records using the DisplayEmployeeInProject function.
                        consoleOutputs.DisplayEmployeeInProject(ListRetrieve);
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