using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WA_automator;

public class Logic
{
    private IBrowserController _browserController;
    public Logic()
    {
        _browserController = new BrowserController();
        _browserController.OpenPage("https://web.whatsapp.com/");
        _browserController.WaitForPageToLoad();
        Console.WriteLine("Page Opened");
        
    }

    public void Authenticate()
    {
        byte[] byteImage = _browserController.GetQrCode();
        
        // Save the bytes to a temporary file
        string filePath = Path.GetTempFileName() + ".jpg";
        
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            fileStream.Write(byteImage, 0, byteImage.Length);
        }

        // Open the file using the native image viewer
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // Windows
            Process.Start("explorer.exe",filePath);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Console.WriteLine(filePath);

            // Open the native image viewer
            Process.Start("qlmanage", "-p " + filePath);
        }
        else
        {
            // Other platforms
            Console.WriteLine("Unable to open image on this platform.");
            _browserController.GetDriver().Manage().Window.Maximize();
        }
    }
    public void SendMessage(string message, string telNumber)
    {
        _browserController.OpenChat(telNumber);
        _browserController.SendMessage(message);
    }
}