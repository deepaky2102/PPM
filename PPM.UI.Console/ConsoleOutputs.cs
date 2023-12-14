using PPM.Model;      // Import the PPM.UI.Model namespace to use classes from it.

namespace PPM.UI.Console
{
    public class ConsoleOutputs
    {
        public void DisplayProject(List<ProjectClass> ListRetrieve)
        {
            int Count = 0;  // Initialize a counter to keep track of the number of items processed.

            System.Console.WriteLine($"|--------------------------------------------------------------------------------------------|");
            System.Console.WriteLine($"|                                       Projects Details                                     |");
            System.Console.WriteLine($"|--------------------------------------------------------------------------------------------|");
            System.Console.WriteLine($"|   Sr. No.   |   Project Id   |            Name           |   StartDate    |     EndDate    |");
            System.Console.WriteLine($"|--------------------------------------------------------------------------------------------|");

            if (ListRetrieve != null && ListRetrieve.Any()) // Check if ListRetrieve is not null and contains at least one item.
            {
                foreach (var item in ListRetrieve)   // Iterate through the list of retrieved project records.
                {
                    Count++;    // Increment the counter for displaying the serial number.

                    // Display project details in a formatted table.
                    System.Console.WriteLine($"|   {Count}   |   {item.ProjectId}   |   {item.Name}   |   {item.StartDate}   |   {item.EndDate}   |");
                    System.Console.WriteLine($"|--------------------------------------------------------------------------------------------|");
                }
            }
            else
            {
                // If the list is empty or null, display "Null" values in the table.
                System.Console.WriteLine($"|    Null     |      Null      |            Null           |      Null      |       Null     |");
                System.Console.WriteLine($"|--------------------------------------------------------------------------------------------|");
            }
        }

        public void DisplayRole(List<RoleClass> ListRetrieve)
        {
            int Count = 0;  // Initialize a counter to keep track of the number of items processed.

            System.Console.WriteLine($"|-------------------------------------------------------|");
            System.Console.WriteLine($"|              Roles Details                            |");
            System.Console.WriteLine($"|-------------------------------------------------------|");
            System.Console.WriteLine($"|   Sr. No.   |   Role Id   |            Name           |");
            System.Console.WriteLine($"|-------------------------------------------------------|");

            if (ListRetrieve != null && ListRetrieve.Any()) // Check if ListRetrieve is not null and contains at least one item.
            {
                foreach (var item in ListRetrieve)   // Iterate through the list of retrieved role records.
                {
                    Count++;    // Increment the counter for displaying the serial number.

                    // Display role details in a formatted table.
                    System.Console.WriteLine($"|   {Count}   |   {item.RoleId}   |   {item.Name}   |");
                    System.Console.WriteLine($"|-------------------------------------------------------|");
                }
            }

            else
            {
                // If the list is empty or null, display "Null" values in the table.
                System.Console.WriteLine($"|    Null     |      Null   |            Null           |");
                System.Console.WriteLine($"|-------------------------------------------------------|");
            }
        }

        public void DisplayEmployee(List<EmployeeClass> ListRetrieve)
        {
            int Count = 0;  // Initialize a counter to keep track of the number of items processed.

            System.Console.WriteLine($"|-----------------------------------------------------------------------------------------------------------------------------------------|");
            System.Console.WriteLine($"|                                                             Employee Details                                                            |");
            System.Console.WriteLine($"|-----------------------------------------------------------------------------------------------------------------------------------------|");
            System.Console.WriteLine($"|   Sr. No.   |   Employee Id   |   First Name   |   Last Name    |     Email    |     Mobile Number    |     Address    |     Role Id    |");
            System.Console.WriteLine($"|-----------------------------------------------------------------------------------------------------------------------------------------|");

            if (ListRetrieve != null && ListRetrieve.Any()) // Check if ListRetrieve is not null and contains at least one item.
            {
                foreach (var item in ListRetrieve)   // Iterate through the list of retrieved employee records.
                {
                    Count++;    // Increment the counter for displaying the serial number.

                    // Display employee details in a formatted table.
                    System.Console.WriteLine($"|   {Count}   |   {item.EmployeeId}   |   {item.FirstName}   |   {item.LastName}   |   {item.Email}   |   {item.MobileNumber}   |   {item.Address}   |   {item.RoleId}   |");
                    System.Console.WriteLine($"|-----------------------------------------------------------------------------------------------------------------------------------------|");
                }
            }
            else
            {
                // If the list is empty or null, display "Null" values in the table.
                System.Console.WriteLine($"|    Null     |      Null       |      Null      |      Null      |      Null    |          Null        |       Null     |       Null     |");
                System.Console.WriteLine($"|-----------------------------------------------------------------------------------------------------------------------------------------|");
            }
        }

        public void DisplayEmployeeInProject(List<EmployeeProjectRelationClass> ListRetrieve)
        {
            int Count = 0;  // Initialize a counter to keep track of the number of items processed.

            System.Console.WriteLine($"|---------------------------------------------------------|");
            System.Console.WriteLine($"|           Employee in Project Details                   |");
            System.Console.WriteLine($"|---------------------------------------------------------|");
            System.Console.WriteLine($"|   Sr. No.   |   Id   |   Project Id   |   Employee Id   |");
            System.Console.WriteLine($"|---------------------------------------------------------|");

            if (ListRetrieve != null && ListRetrieve.Any()) // Check if ListRetrieve is not null and contains at least one item.
            {

                foreach (var item in ListRetrieve)   // Iterate through the list of retrieved role records.
                {
                    Count++;    // Increment the counter for displaying the serial number.


                    System.Console.WriteLine($"|     {Count}      |   {item.Id}    |        {item.ProjectId}       |         {item.EmployeeId}        |");
                    System.Console.WriteLine($"|---------------------------------------------------------|");
                }
            }
            else
            {
                // If the list is empty or null, display "Null" values in the table.
                System.Console.WriteLine($"|    Null     |  Null  |      Null      |       Null      |");
                System.Console.WriteLine($"|---------------------------------------------------------|");
            }
        }
    }
}