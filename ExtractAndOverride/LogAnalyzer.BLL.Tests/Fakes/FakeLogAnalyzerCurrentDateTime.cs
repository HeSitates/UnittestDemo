namespace LogAnalyzer.BLL.Test.Fakes
{
  using System;

  internal class FakeLogAnalyzerCurrentDateTime : LogAnalyzer
  {
    public FakeLogAnalyzerCurrentDateTime(DateTime currentDateTime)
    {
      this.GetCurrentDateTime = currentDateTime;
    }

    protected override DateTime GetCurrentDateTime { get; }
  }
}