namespace MyCalculator.BLL.Test.Custom_Attributes
{
  using System;

  using MyCalculator.BLL.Test.Utilities;

  using NUnit.Framework;
  using NUnit.Framework.Interfaces;

  public class FancySuiteAttribute : Attribute, ITestAction
  {
    private const string ClassDescription = "FancySuiteAttribute";

    public ActionTargets Targets => ActionTargets.Suite;

    public void BeforeTest(ITest test)
    {
      ContextWriter.WriteLine(ClassDescription);
    }

    public void AfterTest(ITest test)
    {
      ContextWriter.WriteLine(ClassDescription);
    }
  }
}