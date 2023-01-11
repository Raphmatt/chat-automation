using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WA_automator;

public class Logic
{
    private IBrowserController _browserController;

    private string localStoragePath =
        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "localStorage.json");

    public Logic()
    {
        _browserController = new BrowserController();
        Console.WriteLine("Page Opened");
    }

    public void Authenticate()
    {
        _browserController.ShowQRCode();
    }

    public void SendMessage(string message, string telNumber)
    {
        _browserController.OpenChat(telNumber);
        _browserController.SendMessage(message);
    }
}