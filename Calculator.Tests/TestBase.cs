namespace MyCalculator.BLL.Test
{
  using MyCalculator.BLL.Test.Utilities;

  using NUnit.Framework;

  public class TestBase
  {
    private const string ClassDescription = "Testbase";

    /******************************************************************************************************************************************************
     * BE CAREFULL: The counter is only to demonstrate that each SetUp/Teardown is called once per class or method.
     * NEVER USE member variables in testclasses, the order in which tests are run can be differ per testrunner or system.
     * Constants are allowed of course.
     * It's also important to notice that testmethods can run multithreaded.
     * ***************************************************************************************************************************************************/
    protected double Counter { get; set; }

    [OneTimeSetUp]
    public void Init()
    {
      ContextWriter.WriteLine(ClassDescription, this.Counter++);
    }

    [SetUp]
    public void BaseSetUp()
    {
      ContextWriter.WriteLine(ClassDescription, this.Counter++);
    }

    [TearDown]
    public void BaseTearDown()
    {
      ContextWriter.WriteLine(ClassDescription, this.Counter++);
    }

    [OneTimeTearDown]
    public void CleanUp()
    {
      ContextWriter.WriteLine(ClassDescription, this.Counter++);
    }
  }
}
