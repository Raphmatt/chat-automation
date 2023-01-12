using Moq;

namespace WA_automator.Test;


public class LogicTest {
    [Fact]
    public void TelNumberValidation_ValidTelNumber()
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
    public void TelNumberValidation_InvalidTelNumber(string telNumber)
    {
        // Arrange
        var logic = new Logic(new Mock<IBrowserController>().Object);
        // Act
        var result = logic.IsValidTelNumber(telNumber);
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void SendMessage_CallsOpen()
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
}