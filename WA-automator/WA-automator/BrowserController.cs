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
    public void OpenChat(string telephoneNumber)
    {
        try
        {
            _webDriver.FindElement(By.XPath("//div[@data-testid='chat-list-search']"))
                .SendKeys(telephoneNumber + Keys.Enter);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Sends a message to the currently opened chat
    /// </summary>
    /// <returns>If the message was sent successfully</returns>
    public bool SendMessage(string message)
    {
        try
        {
            _wait.Until(driver => driver.FindElement(By.XPath("//p[@class='selectable-text copyable-text']")))
                .SendKeys(message + Keys.Enter);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    /// <summary>
    /// Hide everything on the website except the qr code
    /// </summary>
    public void ShowQrCode()
    {
        try
        {
            // wait for qr code to be visible
            _wait.Until(driver => driver.FindElement(By.XPath("//canvas")));
            
            // hide everything except the qr code
            _wait.Until(driver => ((IJavaScriptExecutor)driver) 
                .ExecuteScript(
                    "document.querySelector('div.landing-window > div:nth-child(2)').style.display = 'none';" +
                    "document.querySelector('a').style.display = 'none';" +
                    "document.querySelector('div.landing-header').style.display = 'none';" +
                    "document.querySelector('div.landing-wrapper-before').style.display = 'none';" +
                    "document.querySelector('#initial_startup').style.display = 'none';" +
                    "document.querySelector('#app').style.backgroundColor = 'white';" +
                    "return true;"
                ));
        }
        catch (Exception e)
        {
            
        }

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
}