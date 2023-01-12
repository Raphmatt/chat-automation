using OpenQA.Selenium.Chrome;
using System.Drawing;
using OpenQA.Selenium.Support.UI;

namespace WaAutomator;

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
    public bool OpenChat(string telephoneNumber);

    /// <summary>
    /// Sends a message to the currently opened chat
    /// </summary>
    public bool SendMessage(string message);

    /// <summary>
    /// Hide everything on the website except the qr code
    /// </summary>
    public void ShowQrCode();

    /// <summary>
    /// Logout from whatsapp
    /// </summary>
    public void Logout();

    /// <summary>
    /// Show and hides the Browser
    /// </summary>
    /// <param name="show">True to show window, false to hide</param>
    /// <param name="size">Size of the windows (default w550, h600)</param>
    /// <param name="position">Position of window on screen (default x0, y0)</param>
    public void ShowBrowser(bool show, Size size = default, Point position = default);
}