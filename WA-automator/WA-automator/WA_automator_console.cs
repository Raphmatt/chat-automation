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
        Console.WriteLine("Please enter a command number and press enter.");
            Console.WriteLine("Available commands:");
            Console.WriteLine("1: Send Message Now");
            Console.WriteLine("2: Send Message Later");
            Console.WriteLine("3: Show Contacts");
            Console.WriteLine("4: Read Message");
            Console.WriteLine("5: Exit");
            Console.WriteLine("?: Help");
    }

    static void Executer(string nunbMenu)
    {
        var browsercontroller = new BrowserController();
        WebDriverWait wait = browsercontroller.GetWait();
        ChromeDriver driver = browsercontroller.GetDriver();

        var reference = new Program();

        switch (nunbMenu)
        {
            case "1":
            {
                reference.Send_Message(driver,wait);
            }
                break;
            
            case "2":
            {
                // has to be called with a thread
            }
                break;
                
            case "3":
            {
                reference.Show_Contacts(wait);
            }
                break;
            
            case "4":
            {
                reference.Read_Message(driver,wait);
            }
                break;
            
            default:
            {
                Console.WriteLine("Such a Command is not given");
                Console.WriteLine("Try Again");
            }
                break;
        }
        
    }
    
    
    
}
