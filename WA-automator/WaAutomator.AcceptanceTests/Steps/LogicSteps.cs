using System.Runtime.CompilerServices;
using Moq;


using Moq;
using Xunit;

namespace WaAutomator.AcceptanceTests.Steps;

[Binding]
public sealed class LogicSteps
{
    private readonly IBrowserController _browserController;
    private string msg;
    private Mock<IBrowserController> browserControllerMock;
    private Action act;


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
        logic.SendMessage("Hello World","+41345678907");
    }

    [Then(@"Function should be called")]
    public void ThenFunctionShouldBeCaled()
    {
        browserControllerMock.Verify(b => b.SendMessage(It.IsAny<string>()), Times.Once);
    }

    [Then(@"Function should call Exception")]
    public void ThenFunctionShouldCallException()
    {
        Assert.Throws<ArgumentException>(act);
    }

    [Given(@"Arrange Mock")]
    public void GivenArrangeMock()
    {
        browserControllerMock = new Mock<IBrowserController>();
    }

    [When(@"Sending Empty message")]
    public void WhenSendingEmptyMessage()
    {
        var logic = new Logic(browserControllerMock.Object);
        act = () => logic.SendMessage("", "+41345678907");
    }

    [When(@"User Starts Program")]
    public void WhenUserStartsProgram()
    {
        var logic = new Logic(browserControllerMock.Object);
        logic.Authenticate();
    }

    [Then(@"Function Authenticate should be called")]
    public void ThenFunctionAuthenticateShouldBeCalled()
    {
        browserControllerMock.Verify(b => b.ShowQrCode(), Times.Once);
    }

    [When(@"User Logs Out")]
    public void WhenUserLogsOut()
    {
        var logic = new Logic(browserControllerMock.Object);
        logic.Quit();
    }

    [Then(@"Log Out Function should be called")]
    public void ThenLogOutFunctionShouldBeCalled()
    {
        browserControllerMock.Verify(b => b.Logout(), Times.Once);
    }
}