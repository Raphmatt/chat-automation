using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.Page;
using OpenQA.Selenium.Support.UI;

namespace WA_automator;

public class WA_automator_console
{
    static void Console_Handler()
    {
         string command;
        
        navigation();

        do
        {
            command = Console.ReadLine();
            if (command == "?")
            {
                navigation();
            }
            else
            {
                Executer(command);
            }
            Console.WriteLine("---------------------------------------");
        
        } while (command != "5");

        Environment.Exit(0);
    }

    static void navigation()
    {
        Console.Clear();
        Console.WriteLine(@"---------------------------------------
Please enter a command number and press enter.
Available commands:
1: Send a message
q: Quit");
    }

    static void Executer(string nunbMenu)
    {
        var browserController = new BrowserController();
        WebDriverWait wait = browserController.GetWait();
        ChromeDriver driver = browserController.GetDriver();

        var program = new Program();

        switch (nunbMenu.ToLower())
        {
            case "1":
                program.SendMessage(driver,wait);
                break;
            
            case "q":
                Environment.Exit(0);
                break;
            
            default:
                Console.WriteLine("Such a Command is not given");
                Console.WriteLine("Try Again");
                Console.ReadLine();
                break;
        }
    }
}
