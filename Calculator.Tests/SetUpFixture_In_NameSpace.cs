namespace MyCalculator.BLL.Test
{
  using MyCalculator.BLL.Test.Utilities;

  using NUnit.Framework;

  /// <summary>
  /// SetUpFixture in a namespace will be run once for the entire namespace.
  /// </summary>
  [SetUpFixture]
  public class SetUpFixtureInNameSpace
  {
    private const string ClassDescription = "SetUpFixture IN namespace";

    [OneTimeSetUp]
    public void Init()
    {
      ContextWriter.WriteLine(ClassDescription);
    }

    [OneTimeTearDown]
    public void CleanUp()
    {
      ContextWriter.WriteLine(ClassDescription);
    }
  }
}
