﻿using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
// using WA_automator_logic;

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
            IWebElement element = wait.Until(driver => driver.FindElement(By.XPath("//div[@tabindex='-1']")));
        }
        catch (WebDriverTimeoutException)
        {
            Console.Error.WriteLine("Timeout of 90 Seconds succeeded");
            return;
        }
        Console.WriteLine("Getting list of people");

        ReadOnlyCollection<IWebElement> elements = wait.Until(driver => driver.FindElements(By.XPath("//div[@data-testid='cell-frame-container']//div/div[1]/div/span[@title]")));
        List<IWebElement> people = elements.ToList();
        Console.WriteLine("Found " + people.Count + " people");
        foreach (IWebElement e in people)
        {
            Console.WriteLine(e.Text);
        }

        Console.WriteLine("Name of person you want to chat with: ");
        string name = Console.ReadLine();
        Console.WriteLine("Type the Message you want to send: ");
        string message = Console.ReadLine();
        driver.FindElement(By.XPath($"//span[@title='{name}']")).Click();

        var input = driver.FindElement(By.XPath("//p[@class='selectable-text copyable-text']"));
        input.Click();
        input.SendKeys(message);
        input.SendKeys(Keys.Enter);
        
        Console.ReadLine();
    }

    public void Show_Contacts(WebDriverWait wait)
    {
        Console.WriteLine("Getting list of people");

        ReadOnlyCollection<IWebElement> elements = wait.Until(driver => driver.FindElements(By.XPath("//div[@data-testid='cell-frame-container']//div/div[1]/div/span[@title]")));
        List<IWebElement> people = elements.ToList();
        Console.WriteLine("Found " + people.Count + " people");
        foreach (IWebElement e in people)
        {
            Console.WriteLine(e.Text);
        }
    }

    public void Send_Message(ChromeDriver driver,WebDriverWait wait)
    {
        Console.WriteLine("Name of person you want to chat with: ");
        string name = Console.ReadLine();
        Console.WriteLine("Type the Message you want to send: ");
        string message = Console.ReadLine();
        do
        {
            try
            {
                driver.FindElement(By.XPath($"//span[@title='{name}']")).Click();
                break;
            }
            catch (Exception)
            {
                Console.Error.WriteLine("No such person try again");
                Show_Contacts(wait);
            }
        }while (true);

        var input = driver.FindElement(By.XPath("//p[@class='selectable-text copyable-text']"));
        input.Click();
        input.SendKeys(message);
        input.SendKeys(Keys.Enter);
    }

    public void Send_Message_Later(ChromeDriver driver, WebDriverWait wait, DateTime sendDate)
    {
        Console.WriteLine("Name of person you want to chat with: ");
        string name = Console.ReadLine();
        Console.WriteLine("Type the Message you want to send: ");
        string message = Console.ReadLine();
        do
        {
            try
            {
                driver.FindElement(By.XPath($"//span[@title='{name}']")).Click();
                break;
            }
            catch (Exception)
            {
                Console.Error.WriteLine("No such person try again");
                Show_Contacts(wait);
            }
        }while (true);
        do
        {
            System.Threading.Thread.Sleep(45000);
        } while (DateTime.Now != sendDate);
        
        var input = driver.FindElement(By.XPath("//p[@class='selectable-text copyable-text']"));
        input.Click();
        input.SendKeys(message);
        input.SendKeys(Keys.Enter);
    }

    public void Read_Message(ChromeDriver driver, WebDriverWait wait)
    {
        Console.WriteLine("Name of person you want to chat with: ");
        string name = Console.ReadLine();
        Console.WriteLine("Type the Message you want to send: ");
        string message = Console.ReadLine();
        do
        {
            try
            {
                driver.FindElement(By.XPath($"//span[@title='{name}']")).Click();
                break;
            }
            catch (Exception)
            {
                Console.Error.WriteLine("No such person try again");
                Show_Contacts(wait);
            }
        }while (true);
        //read the message and safe in a list
    }
}