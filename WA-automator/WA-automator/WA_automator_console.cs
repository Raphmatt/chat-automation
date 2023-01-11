using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.Page;
using OpenQA.Selenium.Support.UI;

namespace WA_automator;

public class WA_automator_console
{
    public static void Main()
    {
        string command;
        do
        {
            Logic logic = new Logic();
            logic.Authenticate();
            
            navigation();
            command = Console.ReadLine();
            switch (command.ToLower())
            {
                case "1":
                    Console.WriteLine("Enter the telephone number: ");
                    string telNumber = Console.ReadLine();
                    Console.WriteLine("Type the Message you want to send: ");
                    string message = Console.ReadLine();
                    Console.WriteLine("Sending Message...");
                    
                    new Logic().SendMessage(message, telNumber);
                    break;

                case "q":
                    break;

                default:
                    Console.WriteLine("Such a Command is not given");
                    Console.WriteLine("Try Again");
                    Console.ReadLine();
                    break;
            }
        } while (command.ToLower() != "q");
        
        Environment.Exit(0);
    }

    private static void navigation()
    {
        //Console.Clear();
        Console.WriteLine(@"---------------------------------------
Please enter a command number and press enter.
Available commands:
1: Send a message
q: Quit");
    }
}