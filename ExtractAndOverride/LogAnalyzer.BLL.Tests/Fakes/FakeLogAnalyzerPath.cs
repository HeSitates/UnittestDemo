namespace LogAnalyzer.BLL.Test.Fakes
{
  internal class FakeLogAnalyzerPath : LogAnalyzer
  {
    private readonly bool fakeExistingPath;

    public FakeLogAnalyzerPath(bool pathExist)
    {
      fakeExistingPath = pathExist;
    }

    public override bool IsExistingPath(string fullpath)
    {
      return fakeExistingPath;
    }
  }
}