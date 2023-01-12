using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WaAutomator;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<IBrowserController, BrowserController>())
    .Build();
    
Main(host.Services);
await host.RunAsync();

static void Main(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    
    Logic logic = new Logic(provider.GetRequiredService<IBrowserController>());
    
    logic.Authenticate();

    string input;

    do
    {
        Navigation();

        input = Console.ReadLine() ?? string.Empty;

        switch (input.ToLower())
        {
            case "1":
                SendMessage(logic);
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

static void SendMessage(Logic logic)
{

    Console.Clear();
    Console.WriteLine("Enter the telephone number \"+41000000000\"");
        
    string telNumber = Console.ReadLine() ?? string.Empty;
    if (telNumber == "")
    {
        Console.WriteLine("You have to enter a telephone number");
        Console.ReadKey();
        return;
    }

    if (!logic.IsValidTelNumber(telNumber))
    {
        Console.WriteLine("The telephone number is not valid");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("Type the Message you want to send: ");

    var textMessage = Console.ReadLine() ?? string.Empty;

    if (textMessage == string.Empty)
    {
        Console.WriteLine("Please enter a text message");
        Console.ReadLine();
        return;
    }

    logic.SendMessage(textMessage, telNumber);
    Console.ReadLine();
}

static void Navigation()
{
    Console.Clear();
    Console.WriteLine(@"---------------------------------------
Note: Always quit the program with ""q"" 
      to ensure whatsapp logout
---------------------------------------
Please enter a command number and press enter.
Available commands:
1: Send a message
q: Quit");
}