namespace LogAnalyzer.BLL.Test.Fakes
{
  using System;

  using Interfaces;

  public class FakeExtensionManager : IExtensionManager
  {
    public bool WillBeValid { get; set; }

    public Exception WillThrow { get; set; }

    public bool IsValid(string fileName)
    {
      if (this.WillThrow != null)
      {
        throw this.WillThrow;
      }

      return this.WillBeValid;
    }
  }
}