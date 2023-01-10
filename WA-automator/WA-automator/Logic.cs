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

    public Logic()
    {
        _browserController = new BrowserController();
        Console.WriteLine("Page Opened");
    }

    public void Authenticate()
    {
        var driver = _browserController.GetDriver();
        driver.Manage().Window.Size = new Size(500, 400);
        driver.Manage().Window.Position = new Point(0, 0);
        _browserController.GetWait().Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("" +
            "document.querySelector('.landing-main div div:nth-child(1)').style.display = 'none';" +
            "document.querySelector('.landing-main div a').style.display = 'none';" +
            "document.querySelector('.landing-header').style.display = 'none';" +
            "document.querySelector('.landing-window > div:nth-child(2)').style.display = 'none';" +
            "document.querySelector('.landing-wrapper-before').style.display = 'none';" +
            "document.querySelector('#initial_startup').style.display = 'none';" +
            "document.querySelector('#app').style.backgroundColor = 'white';" +
            "return true;"));
        _browserController.CheckAuthenticated();
        driver.Manage().Window.Minimize();
    }

    public void SendMessage(string message, string telNumber)
    {
        _browserController.OpenChat(telNumber);
        _browserController.SendMessage(message);
    }
}