using System.Drawing;
using System.Reflection;
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

    public void ShowQRCode()
    {
        _webDriver.Manage().Window.Size = new Size(500, 400);
        _webDriver.Manage().Window.Position = new Point(0, 0);
        _wait.Until(driver => ((IJavaScriptExecutor)driver)
            .ExecuteScript(
                "document.querySelector('.landing-main div div:nth-child(1)').style.display = 'none';" +
                "document.querySelector('.landing-main div a').style.display = 'none';" +
                "document.querySelector('.landing-header').style.display = 'none';" +
                "document.querySelector('.landing-window > div:nth-child(2)').style.display = 'none';" +
                "document.querySelector('.landing-wrapper-before').style.display = 'none';" +
                "document.querySelector('#initial_startup').style.display = 'none';" +
                "document.querySelector('#app').style.backgroundColor = 'white';" +
                "return true;"
            ));
        CheckAuthenticated();
        _webDriver.Manage().Window.Minimize();
    }
}