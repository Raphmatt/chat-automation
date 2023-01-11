namespace WA_automator;

public abstract class WaAutomatorConsole
{
    public static void Main()
    {
        Logic logic = new Logic();
        logic.Authenticate();

        string input;

        do
        {
            Navigation();

            input = Console.ReadLine() ?? string.Empty;

            switch (input.ToLower())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Enter the telephone number or a saved name: ");
                    var telephoneNumber = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Type the Message you want to send: ");
                    var textMessage = Console.ReadLine() ?? string.Empty;

                    if (telephoneNumber == "" || textMessage == "")
                    {
                        Console.WriteLine("Please enter a valid telephone number or name and text message");
                        Console.ReadLine();
                        break;
                    }

                    logic.SendMessage(textMessage, telephoneNumber);
                    Console.ReadLine();
                    break;

                case "q":
                    break;

                default:
                    Console.WriteLine("Such a Command is not given");
                    Console.WriteLine("Try Again");
                    Console.ReadLine();
                    break;
            }
        } while (input.ToLower() != "q");

        logic.Quit();
        Environment.Exit(0);
    }

    private static void Navigation()
    {
        Console.Clear();
        Console.WriteLine(@"---------------------------------------
Please enter a command number and press enter.
Available commands:
1: Send a message
q: Quit");
    }
}