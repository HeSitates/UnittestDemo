namespace LogAnalyzer.BLL.Test
{
  using System;

  using Interfaces;

  using Moq;
  using NUnit.Framework;

  [TestFixture]
  public class TestLogAnalyzer
  {
    [Test]
    public void IsValidLogFileNameShouldReturnTrueWhenExtensionManagerValidatesExtension()
    {
      // Arrange
      const bool ExpectedResult = true;
      /********************************************************************************************************************************* 
       * Notice the name:
       * We are not testing the ExtensionManager, hence the name stub
       *********************************************************************************************************************************/
      var stub = new Mock<IExtensionManager>();
      stub.Setup(m => m.IsValid(It.IsAny<string>())).Returns(ExpectedResult);

      var sut = new LogAnalyzer(stub.Object);

      // Act
      var result = sut.IsValidLogFileName("file.log");

      // Assert
      Assert.That(result, Is.EqualTo(ExpectedResult));
    }

    [Test]
    public void IsValidLogFileNameShouldReturnFalseWhenExtensionManagerRejectsExtension()
    {
      // Arrange
      const bool ExpectedResult = false;

      var stub = new Mock<IExtensionManager>();
      stub.Setup(m => m.IsValid(It.IsAny<string>())).Returns(false);

      var sut = new LogAnalyzer(stub.Object);

      // Act
      var result = sut.IsValidLogFileName("file.ext");

      // Assert
      Assert.That(result, Is.EqualTo(ExpectedResult));
    }

    [TestCase(null)]
    [TestCase("")]
    public void IsValidLogFileNameShouldThrowExceptionWhenFilenameIsNullOrEmpty(string filename)
    {
      // Arrange
      const string ExpectedResult = "filename has to be provided";

      var stub = new Mock<IExtensionManager>();
      stub.Setup(m => m.IsValid(It.Is<string>(s => s == filename))).Throws(new ArgumentException(ExpectedResult));

      var sut = new LogAnalyzer(stub.Object);

      // Act
      var result = Assert.Throws<ArgumentException>(() => sut.IsValidLogFileName(filename));

      // Assert
      Assert.That(result.Message, Does.Contain(ExpectedResult));
    }

    [Test]
    public void GetOutputFileNameShouldReturnFileNameBasedOnCurrentDate()
    {
      // Arrange
      const string ExpectedResult = "19630427010203000.log";

      // We're not faking the interface, but the actual object, so this is a mock! 
      // CallBase = true, 'tells' Mock that the base class should be invoked.
      var mock = new Mock<LogAnalyzer> { CallBase = true };

      // Fake a single method (or property).
      mock.Setup(m => m.GetCurrentDateTime).Returns(new DateTime(1963, 4, 27, 1, 2, 3));

      // Act
      // Get the result from another method which calls the faked method (or property).
      var result = mock.Object.GetOutputFileName();

      // Assert
      Assert.That(result, Is.EqualTo(ExpectedResult));
    }
  }
}
