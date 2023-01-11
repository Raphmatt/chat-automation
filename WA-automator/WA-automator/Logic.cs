using System.Drawing;

namespace WA_automator;

public class Logic
{
    private readonly IBrowserController _browserController;

    public Logic()
    {
        _browserController = new BrowserController();
        Console.WriteLine("Page Opened");
    }

    public void Authenticate()
    {
        _browserController.ShowQrCode();
        
        var driver = _browserController.GetDriver();
        driver.Manage().Window.Size = new Size(500, 400);
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
        _browserController.SendMessage(message);
        Console.WriteLine("\nMessage Sent");
    }

    public void Quit()
    {
        _browserController.Logout();
    }
}