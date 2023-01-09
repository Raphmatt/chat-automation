using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WA_automator;

public class Logic
{
    private IBrowserController _browserController;
    public Logic()
    {
        _browserController = new BrowserController();
        _browserController.OpenPage("https://web.whatsapp.com/");
        
    }

    public void Authenticate()
    {
        _browserController.GetQrCode();
    }
    public void SendMessage(string message, string telNumber)
    {
        _browserController.OpenChat(telNumber);
        _browserController.SendMessage(message);
    }
}