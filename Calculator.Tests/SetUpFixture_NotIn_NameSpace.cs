using MyCalculator.BLL.Test.Utilities;

using NUnit.Framework;

/// <summary>
/// SetUpFixture without namespace (!) will be run once for the entire assembly.
/// </summary>
[SetUpFixture]
// ReSharper disable once CheckNamespace
public class SetUpFixtureNotInNameSpace
{
  private const string ClassDescription = "SetUpFixture NOT IN namespace";

  /******************************************************************************************************************************************************
   * BE CAREFULL: The counter is only to demonstrate that each SetUp/Teardown is called once per class or method.
   * NEVER USE member variables in testclasses, the order in which tests are run can be differ per testrunner or system.
   * Constants are allowed of course.
   * It's also important to notice that testmethods can run multithreaded.
   * ***************************************************************************************************************************************************/
  private double Counter { get; set; }

  /// <summary>
  /// The name of the method does not matter for OneTimeSetUp/SetUp/TearDown/OneTimeTearDown methods.
  /// </summary>
  [OneTimeSetUp]
  public void Init()
  {
    ContextWriter.WriteLine(ClassDescription, Counter++);
  }

  [OneTimeTearDown]
  public void CleanUp()
  {
    ContextWriter.WriteLine(ClassDescription, Counter++);
  }
}
