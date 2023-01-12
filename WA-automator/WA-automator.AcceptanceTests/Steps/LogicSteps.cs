using OpenQA.Selenium.DevTools.V85.Target;

namespace WA_automator.AcceptanceTests.Steps;

[Binding]
public sealed class LogicSteps
{
    private readonly IBrowserController _browserController;
    private string msg;
    

    public LogicSteps(ScenarioContext scenarioContext, IBrowserController browserController)
    {
        this._browserController = browserController;
    }

    [Given(@"Type message")]
    public void GivenTypeMessage()
    {
        msg = "Hello, World";
    }
    
    [Given(@"Build mock for message")]
    public void GivenBuildMockForMessage()
    {
        this.Mock = new Mock<IBrowserController>(); 
    }

    [When(@"Sending message")]
    public void WhenSendingMessage()
    {
        _browserController.SendMessage(msg);
    }

    [Then(@"Function should be called")]
    public void ThenFunctionShouldBeCaled()
    {
        
    }
    
}