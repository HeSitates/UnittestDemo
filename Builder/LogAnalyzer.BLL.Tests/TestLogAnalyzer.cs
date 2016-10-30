namespace LogAnalyzer.BLL.Test
{
  using System;
  using System.Collections.Generic;

  using Builders;
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
      var stub = new Mock<IExtensionManager>();
      stub.Setup(m => m.IsValid(It.IsAny<string>()))
          .Returns(ExpectedResult);

      LogAnalyzer sut = new LogAnalyzerBuilder()
          .WithExtensionManager(stub.Object)
          .Build();

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
      stub.Setup(m => m.IsValid(It.IsAny<string>()))
          .Returns(false);

      LogAnalyzer sut = new LogAnalyzerBuilder()
          .WithExtensionManager(stub.Object)
          .Build();

      // Act
      var result = sut.IsValidLogFileName("file.ext");

      // Assert
      Assert.That(result, Is.EqualTo(ExpectedResult));
    }

    [TestCase(null, TestName = "IsValidLogFileNameShouldThrowExceptionWhenFilenameIsNull")]
    [TestCase("", TestName = "IsValidLogFileNameShouldThrowExceptionWhenFilenameIsEmpty")]
    public void IsValidLogFileNameShouldThrowExceptionWhenFilenameIsNullOrEmpty(string filename)
    {
      // Arrange
      const string ExpectedResult = "filename has to be provided";

      var stub = new Mock<IExtensionManager>();
      stub.Setup(m => m.IsValid(It.Is<string>(s => s == filename)))
          .Throws(new ArgumentException(ExpectedResult));

      LogAnalyzer sut = new LogAnalyzerBuilder()
          .WithExtensionManager(stub.Object)
          .Build();

      // Act
      TestDelegate methodToTest = () => sut.IsValidLogFileName(filename);
      var result = Assert.Throws<ArgumentException>(methodToTest);

      // Assert
      Assert.That(result.Message, Does.Contain(ExpectedResult));
    }

    [TestCase(null, TestName = "IsValidLogFileNameShouldThrowExceptionWhenFilenameIsNullWithFluent")]
    [TestCase("", TestName = "IsValidLogFileNameShouldThrowExceptionWhenFilenameIsEmptyWithFluent")]
    public void IsValidLogFileNameShouldThrowExceptionWhenFilenameIsNullOrEmptyWithFluent(string filename)
    {
      // Arrange
      const string ExpectedResult = "filename has to be provided";

      var stub = new Mock<IExtensionManager>();
      stub.Setup(m => m.IsValid(It.Is<string>(s => s == filename)))
          .Throws(new ArgumentException(ExpectedResult));

      LogAnalyzer sut = new LogAnalyzerBuilder()
          .WithExtensionManager(stub.Object)
          .Build();

      // Act
      TestDelegate methodToTest = () => sut.IsValidLogFileName(filename);

      // Assert
      Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.Contains(ExpectedResult), methodToTest);
    }

    [Test]
    public void DemoTest()
    {
      // Arrange
      var list = new List<string> { "a", "b", "c", "d", "a" };

      //// Assert.That(list, Has.Exactly(1).EqualTo("a"));
      Assert.That(list, Has.Count.GreaterThan(3).And.Exactly(2).With.LessThan("b"));
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
