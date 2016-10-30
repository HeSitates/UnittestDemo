namespace LogAnalyzer.BLL.Test.Fakes
{
  using Interfaces;

  internal class FakeLogAnalyzerExtensionManager : LogAnalyzer
  {
    private readonly IExtensionManager manager;

    public FakeLogAnalyzerExtensionManager(IExtensionManager mgr)
    {
      manager = mgr;
    }

    protected override IExtensionManager GetManager()
    {
      return manager;
    }
  }
}