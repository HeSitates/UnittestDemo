namespace MyCalculator.BLL.Test
{
  using MyCalculator.BLL.Test.Custom_Attributes;
  using MyCalculator.BLL.Test.Utilities;

  using NUnit.Framework;

  [FancySuite]
  [TestFixture]
  public class TestCalcultor : TestBase
  {
    /// <summary>
    /// OneTimeSetUp is only ran once per testsession before the other testmethods including SetUps
    /// </summary>
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      ContextWriter.WriteLine(this.Counter++);
    }

    /// <summary>
    /// SetUp methods will be executed before each individual test.
    /// If a test has multiple TestCase attributes it wil run before each TestCase!
    /// </summary>
    [SetUp]
    public void SetUp()
    {
      ContextWriter.WriteLine(this.Counter++);
    }

    /// <summary>
    /// You can have multiple SetUp and TearDown methods
    /// </summary>
    /// <remarks>Do NOT rely on the order in which methods will be executed! It can vary on different systems or with different runners!</remarks>
    [TearDown]
    [SetUp]
    public void SetUpTearDown()
    {
      ContextWriter.WriteLine(this.Counter++);
    }

    /// <summary>
    /// TearDown methods will be executed before each individual test.
    /// If a test has multiple TestCase attributes it wil run before each TestCase!
    /// </summary>
    [TearDown]
    public void TearDown()
    {
      ContextWriter.WriteLine(this.Counter++);
    }

    /// <summary>
    /// OneTimeSetUp is only ran once per testsession after the other testmethods including TearDowns
    /// </summary>
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      ContextWriter.WriteLine(this.Counter++);
    }

    [Test(Author = "Your Name", Description = "Extra information about the test. It is however not shown in most runners")]
    public void ANewCalculatorShouldReturnZero()
    {
      // Arrange
      const double ExpectedResult = 0;
      var sut = CreateCalculator();

      // Act
      var actualResult = sut.Result;

      // Assert
      Assert.That(actualResult, Is.EqualTo(ExpectedResult));
    }

    /// <summary>
    /// If the value you use in your test is not important, then please use random values, so other devlopers see that the value is not relevant.
    /// </summary>
    /// <param name="value">A random value</param>
    /// <remarks>Format Random(minValue, maxValue, numberOfValues)</remarks>
    [Test]
    public void AddShouldReturnSameValueWhenValueIsAdded([Random(-10.0, 10.0, 5)] double value)
    {
      // Arrange
      var sut = CreateCalculator();
      sut.Add(value);

      // Act
      var actualResult = sut.Result;

      // Assert
      Assert.That(actualResult, Is.EqualTo(value));
    }

    /// <summary>
    /// Never use logic to determine the expected result!
    /// </summary>
    /// <param name="valuesToAdd">Values are random values.</param>
    /// <remarks>Ignored tests are shown in the output of the NUnit console runner.</remarks>
    [Ignore("Wrong way of validating result.")]
    [TestCase(2, 3, TestName = "Test 3 + 2 = 5")]
    [TestCase(3, 4, TestName = "Test 3 + 4 = 7")]
    [TestCase(2, 3, 4, TestName = "Test 2 + 3 + 4 = 9")]
    public void WrongWayOfAddShouldReturnSumWhenMultipleValuesAreAdded(params double[] valuesToAdd)
    {
      // Arrange
      var sut = CreateCalculator();
      var total = 0D;

      // Act
      foreach (var valueToAdd in valuesToAdd)
      {
        sut.Add(valueToAdd);
        total += valueToAdd; // What if calculation is wrong? Your test would not notice it!
      }

      var actualResult = sut.Result;

      // Assert
      Assert.That(actualResult, Is.EqualTo(total));
    }

    /// <summary>
    /// With the TestCase attribute you can test multiple values in the same test.
    /// </summary>
    /// <param name="sum">The expected result</param>
    /// <param name="valuesToAdd">The values to add up.</param>
    /// <remarks>Notice the Assert-step in this method</remarks>
    [Test(Description = "All values are random values!")]
    [TestCase(5, 2, 3, TestName = "Test 3 + 2 = 5")]
    [TestCase(7, 3, 4, TestName = "Test 3 + 4 = 7")]
    [TestCase(9, 2, 3, 4, TestName = "Test 2 + 3 + 4 = 9")]
    public void AddShouldReturnSumWhenMultipleValuesAreAdded(double sum, params double[] valuesToAdd)
    {
      // Arrange
      var sut = CreateCalculator();

      // Act
      foreach (var valueToAdd in valuesToAdd)
      {
        sut.Add(valueToAdd);
      }

      var actualResult = sut.Result;

      // Assert
      Assert.That(actualResult, Is.EqualTo(sum));
    }

    /// <summary>
    /// Same test as above but with Expected result as a return value.
    /// With the TestCase attribute you can test multiple values in the same test.
    /// </summary>
    /// <param name="valuesToAdd">The values to add up.</param>
    /// <remarks>Notice the lack of the Assert-step in this method.</remarks>
    /// <returns>The <see cref="double"/>.</returns>
    [Test(Description = "Not preferred IMHO because of missing Assert in test itself.")]
    [Category("TestCategory")]
    [Explicit("Same test as above.")]
    [TestCase(2, 3, ExpectedResult = 5)]
    [TestCase(3, 4, ExpectedResult = 7)]
    [TestCase(2, 3, 4, ExpectedResult = 9.0D)]
    public double AddShouldReturnSumWhenMultipleValuesAreAdded(params double[] valuesToAdd)
    {
      // Arrange
      var sut = CreateCalculator();

      // Act
      foreach (var valueToAdd in valuesToAdd)
      {
        sut.Add(valueToAdd);
      }

      var actualResult = sut.Result;

      // Assert??
      return actualResult;
    }

    [Test]
    public void ClearShouldResetValueToZeroWhenClearIsCalled([Random(-1.0, 1.0, 5)] double value)
    {
      // Arrange
      const double ExpectedResult = 0;
      var sut = CreateCalculator();

      // Act
      sut.Add(value);
      sut.Clear();
      var actualResult = sut.Result;

      // Assert
      Assert.That(actualResult, Is.EqualTo(ExpectedResult));
    }

    [FancyTest]
    [Test]
    public void DemoTest()
    {
      // Arrange
      var list = new System.Collections.Generic.List<string> { "a", "b", "c", "d", "a" };

      //// Assert.That(list, Has.Exactly(1).EqualTo("a"));
      Assert.That(list, Has.Count.GreaterThan(3).And.Exactly(2).With.LessThan("b"));
    }

    private Calculator CreateCalculator()
    {
      return new Calculator();
    }
  }
}
