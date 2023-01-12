using System.Drawing;
using System.Text.RegularExpressions;

namespace WaAutomator;

public class Logic
{
    private readonly IBrowserController _browserController;

    public Logic(IBrowserController browserController)
    {
        _browserController = browserController;
        Console.WriteLine("Page Opened");
    }

    public void Authenticate()
    {
        _browserController.ShowQrCode();
        _browserController.ShowBrowser(true, new Size(550, 600));
        
        _browserController.CheckAuthenticated();
        _browserController.ShowBrowser(false);
    }

    public void SendMessage(string message, string telNumber)
    {
        if (message == "")
            throw new ArgumentException("Message cannot be empty");
        if (telNumber == "")
            throw new ArgumentException("Phone number cannot be empty");

            Console.Clear();

        Console.WriteLine("Opening Chat");

        if (_browserController.OpenChat(telNumber))
        {
            Console.WriteLine("Chat Opened\n");
            Console.WriteLine("Sending Message: \"" + message + "\" to " + telNumber);
            if (_browserController.SendMessage(message))
            {
                Console.WriteLine("Message Sent\n");
                return;
            }
        }
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