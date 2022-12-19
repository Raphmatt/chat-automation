using OpenQA.Selenium.Chrome;

namespace WA_automator;

public class Program
{
    public static void Main()
    {
        var browsercontroller = new BrowserController();
        var wait = browsercontroller.GetWait();
        var driver = browsercontroller.GetDriver();
        
        string baseUrl = "https://web.whatsapp.com/";
        driver.Navigate().GoToUrl(baseUrl);
    }
}