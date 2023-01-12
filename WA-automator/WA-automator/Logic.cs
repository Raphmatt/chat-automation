using System.Drawing;
using System.Text.RegularExpressions;

namespace WA_automator;

public class Logic
{
    private readonly IBrowserController _browserController;

    public Logic(IBrowserController browserController)
    {
        _browserController = browserController ?? new BrowserController();
        Console.WriteLine("Page Opened");
    }

    public void Authenticate()
    {
        _browserController.ShowQrCode();

        var driver = _browserController.GetDriver();
        driver.Manage().Window.Size = new Size(550, 600);
        driver.Manage().Window.Position = new Point(0, 0);


        _browserController.CheckAuthenticated();
        driver.Manage().Window.Minimize();
    }

    public void SendMessage(string message, string telNumber)
    {
        Console.Clear();

        Console.WriteLine("Opening Chat");
        _browserController.OpenChat(telNumber);
        Console.WriteLine("Chat Opened\n");

        Console.WriteLine("Sending Message: \"" + message + "\" to " + telNumber);
        
        if(_browserController.SendMessage(message))
            Console.WriteLine("Message Sent\n");
        else
            Console.WriteLine("Message Not Sent\n");
    }
    
    /// <summary>
    /// Checks if given string is a valid phone number
    /// </summary>
    /// <param name="telNumber"></param>
    public bool IsValidTelNumber(string telNumber)
    {
        //check if telephoneNumber is valid to following regex
        //^\+[1-9]\d{1,14}$
        return Regex.IsMatch(telNumber, @"^\+[1-9]\d{1,14}$");
    }

    public void Quit()
    {
        _browserController.Logout();
    }
}