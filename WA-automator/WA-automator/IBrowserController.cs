using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WA_automator;

public interface IBrowserController
{
    /// <summary>
    /// Returns the current wait object
    /// </summary>
    /// <returns></returns>
    public WebDriverWait GetWait();

    /// <summary>
    /// Returns the current web driver
    /// </summary>
    /// <returns></returns>
    public ChromeDriver GetDriver();

    /// <summary>
    /// Checks if the user is logged in by checking if a specific element is present on the page.
    /// </summary>
    public void CheckAuthenticated();

    /// <summary>
    /// Opens the chat of a specified telephone number
    /// </summary>
    public void OpenChat(string telephoneNumber);

    /// <summary>
    /// Sends a message to the currently opened chat
    /// </summary>
    public IWebElement SendMessage(string message);

    void ShowQRCode();
}