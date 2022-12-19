using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WA_automator;

public class BrowserController
{
    private ChromeDriver _webDriver;
    private WebDriverWait _wait;
    
    public BrowserController()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _webDriver = new ChromeDriver();
        _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
    }
    
    public WebDriverWait GetWait()
    {
        return _wait;
    }
    public ChromeDriver GetDriver()
    {
        return _webDriver;
    }
}