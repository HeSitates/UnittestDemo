// ReSharper disable once CheckNamespace
namespace DifferentNamespace.Tests
{
  using MyCalculator.BLL.Test.Utilities;

  using NUnit.Framework;

  [TestFixture]
  [Category("TestCategory")]
  public class TestDifferentNameSpace
  {
    private const string ClassDescription = "Different namespace";

    [Test]
    public void SimpleTestToDemonstrateNUnitCapabillities()
    {
      ContextWriter.WriteLine(ClassDescription);
    }
  }
}
