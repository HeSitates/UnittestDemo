namespace LogAnalyzer.BLL.Test
{
  using System;

  using global::LogAnalyzer.BLL.Test.Fakes;

  using NUnit.Framework;

  [TestFixture]
  public class TestLogAnalyzer
  {
    [Test]
    public void IsValidLogFileNameShouldReturnTrueWhenExtensionManagerValidatesExtension()
    {
      const bool ExpectedResult = true;
      var stub = new FakeExtensionManager { WillBeValid = true };
      var analyzer = new FakeLogAnalyzerExtensionManager(stub);
      var result = analyzer.IsValidLogFileName("file.ext");
      Assert.That(result, Is.EqualTo(ExpectedResult));
    }

    [Test]
    public void IsValidLogFileNameShouldReturnFalseWhenExtensionManagerRejectsExtension()
    {
      const bool ExpectedResult = false;
      var stub = new FakeExtensionManager { WillBeValid = false };
      var analyzer = new FakeLogAnalyzerExtensionManager(stub);
      var result = analyzer.IsValidLogFileName("file.ext");
      Assert.That(result, Is.EqualTo(ExpectedResult));
    }

    [TestCase(null, TestName = "IsValidLogFileNameShouldThrowExceptionWhenFilenameIsNull")]
    [TestCase("", TestName = "IsValidLogFileNameShouldThrowExceptionWhenFilenameIsEmpty")]
    public void IsValidLogFileNameShouldThrowExceptionWhenFilenameIsNullOrEmpty(string filename)
    {
      const string ExpectedResult = "No filename provided";
      var stub = new FakeExtensionManager { WillThrow = new ArgumentException("No filename provided") };
      var analyzer = new FakeLogAnalyzerExtensionManager(stub);
      var result = Assert.Throws<ArgumentException>(() => analyzer.IsValidLogFileName(filename));
      Assert.That(result.Message, Does.Contain(ExpectedResult));
    }

    [Test]
    public void GetOutputFileNameShouldReturnFileNameBasedOnCurrentDate()
    {
      const string ExpectedResult = "19630427010203000.log";
      var analyzer = new FakeLogAnalyzerCurrentDateTime(new DateTime(1963, 4, 27, 1, 2, 3));
      var result = analyzer.GetOutputFileName();
      Assert.That(result, Is.EqualTo(ExpectedResult));
    }

    [Test]
    public void IsExistingPathShouldReturnTrueWhenPathExists()
    {
      const bool ExpectedResult = true;
      var analyzer = new FakeLogAnalyzerPath(true);
      var result = analyzer.IsExistingPath(@"c:\");
      Assert.That(result, Is.EqualTo(ExpectedResult));
    }
  }
}
