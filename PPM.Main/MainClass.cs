using PPM.UI.Console;     // Import the PPM.UI.Console namespace to use classes from it.
using PPM.Xml;
namespace PPM.Main
{
    public class MainClass
    {
        public static void Main(String[] args)
        {
            // XmlDataManager xmlDataManager = new();
            try
            {
                // xmlDataManager.RetrieveButton();
                MainMenuClass.MainMenuOption();     // Call the MainMenuOption method to start the PPM project.
            }
            catch (Exception exp)
            {
                // Handle any exceptions that may occur and display an error message.
                System.Console.WriteLine($"!---- Error Message: {exp.Message} ----!");
            }
        }
        protected MainClass()
        {
        }
    }
}