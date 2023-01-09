using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WA_automator;

public class BrowserController : IBrowserController
{
    private ChromeDriver _webDriver;
    private WebDriverWait _wait;
    
    public BrowserController()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _webDriver = new ChromeDriver();
        _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(90));
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
    /// Opens the specified URL in the browser and waits for the page to load.
    /// </summary>
    /// <param name="url"></param>
    public void OpenPage(string url)
    {
        _webDriver.Navigate().GoToUrl(url);
        _wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
    }

    public void GetQrCode()
    {
        IWebElement canvas = _webDriver.FindElement(By.XPath("//canvas[@aria-label='Scan me!']"));
        var canvasBase64 =
            _webDriver.ExecuteScript("return arguments[0].toDataURL('image/png').substring(21);", canvas);
        Console.WriteLine(canvasBase64);
    }
    /// <summary>
    /// Checks if the user is logged in by checking if a specific element is present on the page.
    /// </summary>
    public void CheckAuthenticated()
    {
        IWebElement element = _wait.Until(driver => driver.FindElement(By.XPath("//div[@tabindex='-1']")));
    }
    /// <summary>
    /// Opens the chat of a specified telephone number
    /// </summary>
    public IWebElement OpenChat(string telephoneNumber)
    {
        return _wait.Until(driver => driver.FindElement(By.XPath("//div[@data-testid='chat-list-search']")));
    }
    /// <summary>
    /// Sends a message to the currently opened chat
    /// </summary>
    public IWebElement SendMessage(string message)
    {
        return _wait.Until(driver => driver.FindElement(By.XPath("//p[@class='selectable-text copyable-text']")));
    }
}