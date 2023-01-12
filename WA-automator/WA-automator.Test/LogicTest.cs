using Moq;

namespace WA_automator.Test;


public class LogicTest {
    [Fact]
    public void LogicTelNumberValidation_ValidTelNumber()
    {
        // Arrange
        var telNumber = "+41345678907";
        var logic = new Logic(new Mock<IBrowserController>().Object);
        // Act
        var result = logic.IsValidTelNumber(telNumber);
        // Assert
        Assert.True(result);
    }
    [Theory]
    [InlineData("+41 345 67 89")]
    [InlineData("41345678907")]
    [InlineData("0041345678907")]
    [InlineData("0041 345 67 89")]
    public void LogicTelNumberValidation_InvalidTelNumber(string telNumber)
    {
        // Arrange
        var logic = new Logic(new Mock<IBrowserController>().Object);
        // Act
        var result = logic.IsValidTelNumber(telNumber);
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void LogicSendMessage_CallsSendMessage()
    {
        // Arrange
        Mock<IBrowserController> browserControllerMock = new Mock<IBrowserController>();
        browserControllerMock.Setup(b => b.OpenChat(It.IsAny<string>())).Returns(true);
        browserControllerMock.Setup(b => b.SendMessage(It.IsAny<string>())).Returns(true);
        var logic = new Logic(browserControllerMock.Object);

        // Act
        logic.SendMessage("+41345678907", "Hello World");
        
        // Assert
        browserControllerMock.Verify(b => b.SendMessage(It.IsAny<string>()), Times.Once);
    }
    
    [Fact]
    public void LogicSendMessage_CallsOpenChat()
    {
        // Arrange
        Mock<IBrowserController> browserControllerMock = new Mock<IBrowserController>();
        browserControllerMock.Setup(b => b.OpenChat(It.IsAny<string>())).Returns(true);
        browserControllerMock.Setup(b => b.SendMessage(It.IsAny<string>())).Returns(true);
        var logic = new Logic(browserControllerMock.Object);

        // Act
        logic.SendMessage("+41345678907", "Hello World");
        
        // Assert
        browserControllerMock.Verify(b => b.OpenChat(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void LogicSendMessage_NoMessageGivenReturnsArgumentException()
    {
        // Arrange
        Mock<IBrowserController> browserControllerMock = new Mock<IBrowserController>();
        Logic logic = new Logic(browserControllerMock.Object);
        
        // Act
        Action act = () => logic.SendMessage("", "+41345678907");
        
        // Assert
        Assert.Throws<ArgumentException>(act);
    }
    
    [Fact]
    public void LogicSendMessage_NoTelNumberGivenReturnsArgumentException()
    {
        // Arrange
        Mock<IBrowserController> browserControllerMock = new Mock<IBrowserController>();
        Logic logic = new Logic(browserControllerMock.Object);
        
        // Act
        Action act = () => logic.SendMessage("Hello World", "");
        
        // Assert
        Assert.Throws<ArgumentException>(act);
    }
    
    [Fact]
    public void LogicAuthenticate_CallsShowQRCode()
    {
        // Arrange
        Mock<IBrowserController> browserControllerMock = new Mock<IBrowserController>();
        Logic logic = new Logic(browserControllerMock.Object);
        
        // Act
        logic.Authenticate();
        
        // Assert
        browserControllerMock.Verify(b => b.ShowQrCode(), Times.Once);
    }

    [Fact]
    public void LogicQuit()
    {
        // Arrange
        Mock<IBrowserController> browserControllerMock = new Mock<IBrowserController>();
        Logic logic = new Logic(browserControllerMock.Object);
        
        // Act
        logic.Quit();
        
        // Assert
        browserControllerMock.Verify(b => b.Logout(), Times.Once);
    }
}