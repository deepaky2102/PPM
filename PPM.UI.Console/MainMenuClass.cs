using PPM.Xml;

namespace PPM.UI.Console
{
    public class MainMenuClass
    {
        protected MainMenuClass()
        {
        }
        public static void MainMenuOption()
        {
            ConsoleInputs consoleInputs = new();
            EmployeeMenuClass employeeMenuClass = new();
            EmployeeProjectRelationMenu employeeProjectRelationMenu = new();
            ProjectMenuClass projectMenuClass = new();
            RoleMenuClass roleMenuClass = new();
            // XmlDataManager xmlDataManager = new();            

            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.
                System.Console.WriteLine("Welcome to Prolifics Project Manager,");

                // Start a loop to display the main menu and handle user input.
                do
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|--------------------------------------------|");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|                  Main Menu                 |");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|--------------------------------------------|");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|    1) Project Menu                         |");
                    System.Console.WriteLine("|    2) Employee Menu                        |");
                    System.Console.WriteLine("|    3) Role Menu                            |");
                    System.Console.WriteLine("|    4) Project and Employee Details Menu    |");
                    System.Console.WriteLine("|    5) Save                                 |");
                    System.Console.WriteLine("|    6) Quit                                 |");
                    System.Console.WriteLine("|                                            |");
                    System.Console.WriteLine("|--------------------------------------------|");

                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {
                        case 1:     // Case 1: Handle Project Menu.
                            projectMenuClass.ProjectMenuOption();
                            break;

                        case 2:     // Case 2: Handle Employee Menu.
                            employeeMenuClass.EmployeeMenuOption();
                            break;

                        case 3:     // Case 3: Handle Role Menu.
                            roleMenuClass.RoleMenuOption();
                            break;

                        case 4:     // Case 4: Handle Project and Employee Details Menu.
                            employeeProjectRelationMenu.EmployeeProjectRelationMenuOption();
                            break;

                        case 5: 
                            
                            // xmlDataManager.UpdateAndSaveDataButton();
                            break;
                        case 6:     // Case 5: Terminate the program.
                            System.Console.WriteLine("---- Prolifics Project Manager Session Out ----");
                            
                            // xmlDataManager.UpdateAndSaveDataButton();
                            Environment.Exit(0);
                            break;

                        default:     // Case Default: Handle invalid menu options.
                            System.Console.WriteLine("---- Invalid Main Menu Option ----");
                            break;
                    }
                    if (Option == 0 || Option == 6)
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
    }
}