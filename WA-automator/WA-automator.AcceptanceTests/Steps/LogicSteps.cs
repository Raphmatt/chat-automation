using System.Runtime.CompilerServices;
using Moq;


using Moq;

namespace WA_automator.AcceptanceTests.Steps;

[Binding]
public sealed class LogicSteps
{
    private readonly IBrowserController _browserController;
    private string msg;
    private Mock<IBrowserController> browserControllerMock;
    

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
        browserControllerMock = new Mock<IBrowserController>();
        browserControllerMock.Setup(b => b.SendMessage(It.IsAny<string>())).Returns(true);
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