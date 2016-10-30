namespace LogAnalyzer.BLL
{
  using System;

  using global::LogAnalyzer.BLL.Interfaces;

  public class WebService : IWebService
  {
    public string Url { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public void TransferLog(string[] analyzedLog)
    {
      throw new NotImplementedException();
    }
  }
}