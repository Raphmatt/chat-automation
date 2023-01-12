using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WA_automator;

public class BrowserController : IBrowserController
{
    private readonly ChromeDriver _webDriver;
    private readonly WebDriverWait _wait;

    public BrowserController()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

        var options = new ChromeOptions();
        options.AddExcludedArgument("enable-automation");
        options.AddArgument("--app=https://web.whatsapp.com");
        _webDriver = new ChromeDriver(options);
        _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(90));
        _webDriver.Manage().Window.Size = new Size(0, 0);
        _webDriver.Manage().Window.Minimize();
    }

    /// <summary>
    /// Returns the current wait object
    /// </summary>
    /// <returns></returns>
    public WebDriverWait GetWait()
    {
        return _wait;
    }

    /// <summary>
    /// Returns the current web driver
    /// </summary>
    /// <returns></returns>
    public ChromeDriver GetDriver()
    {
        return _webDriver;
    }

    /// <summary>
    /// Checks if the user is logged in by checking if a specific element is present on the page.
    /// </summary>
    public void CheckAuthenticated()
    {
        _wait.Until(driver =>
            driver.FindElement(By.XPath("//div[@tabindex='-1']"))); // add try catch here to catch timeout exception
    }

    /// <summary>
    /// Opens the chat of a specified telephone number
    /// </summary>
    /// <returns>Returns true if successfully</returns>
    public bool OpenChat(string telephoneNumber)
    {
        var element = _webDriver.FindElement(By.XPath("//div[@data-testid='chat-list-search']"));
        element.Click();    
        element.SendKeys(telephoneNumber);
        Thread.Sleep(500);
        element.SendKeys(Keys.Enter);
        var elements = _webDriver.FindElements(By.XPath("//div[@data-testid='search-no-chats-or-contacts']"));
        bool result = elements.Count == 0;
        if (!result)
        {
            element.Clear();
            return result;   
        }

        return result;
    }

    /// <summary>
    /// Sends a message to the currently opened chat
    /// </summary>
    /// <returns>Returns true if successfully</returns>
    public bool SendMessage(string message)
    {
        var messageInput = "//p[@class='selectable-text copyable-text']";
        var elements = _webDriver.FindElements(By.XPath(messageInput));
        if (elements.Count > 0)
        {
            elements.First().SendKeys(message + Keys.Enter);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Hide everything on the website except the qr code
    /// </summary>
    public void ShowQrCode()
    {
        new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10)).Until(
            driver => driver.FindElements(By.XPath("//canvas")).Count > 0);

        ((IJavaScriptExecutor)_webDriver)
            .ExecuteScript(
                "document.querySelector('div.landing-window > div:nth-child(2)').style.display = 'none';" +
                "document.querySelector('a').style.display = 'none';" +
                "document.querySelector('div.landing-header').style.display = 'none';" +
                "document.querySelector('div.landing-wrapper-before').style.display = 'none';" +
                "document.querySelector('#initial_startup').style.display = 'none';" +
                "document.querySelector('#app').style.backgroundColor = 'white';" +
                "return true;"
            );
    }
    
    

    /// <summary>
    /// Logout from whatsapp
    /// </summary>
    public void Logout()
    {
        _wait.Until(driver => driver.FindElement(By.XPath("//span[@data-testid='menu']"))).Click();
        _wait.Until(driver => driver.FindElement(By.XPath("//div[@role='application']")))
            .SendKeys(Keys.Up + Keys.Enter);
        _wait.Until(driver => driver.FindElement(By.XPath("//div[@data-testid='popup-controls-ok']")))
            .SendKeys(Keys.Tab + Keys.Tab + Keys.Enter);
    }

    /// <summary>
    /// Show and hides the Browser
    /// </summary>
    /// <param name="show">True to show window, false to hide</param>
    /// <param name="size">Size of the windows (default w550, h600)</param>
    /// <param name="position">Position of window on screen (default x0, y0)</param>
    public void ShowBrowser(bool show, Size size = default, Point position = default)
    {
        
        if (show)
        {
            _webDriver.Manage().Window.Size = size == default ? new Size(550, 600) : size;
            _webDriver.Manage().Window.Position = position == default ? new Point(0, 0) : position;
        }
        else
        {
            _webDriver.Manage().Window.Minimize();
        }
    }
}