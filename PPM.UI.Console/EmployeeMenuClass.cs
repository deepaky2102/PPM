namespace PPM.UI.Console
{
    public class EmployeeMenuClass
    {
        readonly ConsoleInputs consoleInputs = new();
        readonly DeleteMenuClass deleteMenuClass = new();
        readonly InsertClass insertClass = new();
        readonly ViewMenuClass viewMenuClass = new();

        public void EmployeeMenuOption()
        {
            try
            {
                int Option;     // Variable to store the user's menu option.
                System.Console.Clear();     // Clear the console screen.

                // Start a loop to display the employee menu and handle user input.
                do
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("|----------------------------|");
                    System.Console.WriteLine("|                            |");
                    System.Console.WriteLine("|       Employee Menu        |");
                    System.Console.WriteLine("|                            |");
                    System.Console.WriteLine("|----------------------------|");
                    System.Console.WriteLine("|                            |");
                    System.Console.WriteLine("|    1) Add Employee         |");
                    System.Console.WriteLine("|    2) View Employees       |");
                    System.Console.WriteLine("|    3) Delete Employees     |");
                    System.Console.WriteLine("|    4) Quit Employee Menu   |");
                    System.Console.WriteLine("|    5) Main Menu            |");
                    System.Console.WriteLine("|                            |");
                    System.Console.WriteLine("|----------------------------|");
                    
                    Option = consoleInputs.Option();    // Call a method to retrieve the user's selected option from the Menu.

                    // Use a switch statement to handle different menu options.
                    switch (Option)
                    {
                        case 1:     // Case 1: Handle Add Employee.
                            insertClass.InsertEmployeeDetails();
                            break;

                        case 2:     // Case 2: Handle View Employees.
                            viewMenuClass.ViewEmployeeMenu();
                            break;

                        case 3:     // Case 3: Handle Delete Employees.
                            deleteMenuClass.DeleteEmployeeMenu();
                            break;

                        case 4:     //  Case 4: Handle to terminate the loop.
                            System.Console.WriteLine("---- Returning to Main Menu ----");
                            break;

                        case 5:     // Case 5: Handle Main Menu.
                            MainMenuClass.MainMenuOption();
                            break;

                        default:     // Case Default: Handle invalid menu options.
                            System.Console.WriteLine("---- Invalid Employee Menu Option Input ----");
                            break;
                    }
                    if (Option == 0 || Option == 4)
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
    }
}