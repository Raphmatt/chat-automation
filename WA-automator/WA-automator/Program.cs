using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WA_automator;

public class Program
{
    public static void Main()
    {
        var browsercontroller = new BrowserController();
        WebDriverWait wait = browsercontroller.GetWait();
        ChromeDriver driver = browsercontroller.GetDriver();
        
        string baseUrl = "https://web.whatsapp.com/";
        driver.Navigate().GoToUrl(baseUrl);
        wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        Console.WriteLine("Page loaded");
        Console.WriteLine("Please scan the QR code in the next 90 seconds");

        try
        {
            IWebElement element = wait.Until(d => d.FindElement(By.XPath("//div[@tabindex='-1']")));
        }
        catch (WebDriverTimeoutException)
        {
            Console.Error.WriteLine("Timeout of 90 Seconds succeeded");
            return;
        }
        
        Console.ReadLine();
        
        
    }
}