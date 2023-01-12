using System.Runtime.CompilerServices;
using Moq;


using Moq;

namespace WaAutomator.AcceptanceTests.Steps;

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
        browserControllerMock.Setup(b => b.OpenChat(It.IsAny<string>())).Returns(true);
    }

    [When(@"Sending message")]
    public void WhenSendingMessage()
    {
        var logic = new Logic(browserControllerMock.Object);
        logic.SendMessage("+41345678907", "Hello World");
    }

    [Then(@"Function should be called")]
    public void ThenFunctionShouldBeCaled()
    {
        browserControllerMock.Verify(b => b.SendMessage(It.IsAny<string>()), Times.Once);
    }
    
}