namespace LogAnalyzer.BLL
{
  using System;
  using System.Collections.Generic;
  using System.IO;

  using Interfaces;

  public class LogAnalyzer
  {
    private readonly IExtensionManager manager;

    // private readonly IWebService webService;

    public LogAnalyzer()
    {
      manager = new FileExtensionManager();
      // webService = new WebService();
    }

    internal LogAnalyzer(IExtensionManager manager) // , IWebService webService)
    {
      this.manager = manager;
      // this.webService = webService;
    }

    protected internal virtual DateTime GetCurrentDateTime => DateTime.Now;

    public virtual bool IsExistingPath(string fullpath)
    {
      return Directory.Exists(fullpath);
    }

    internal bool IsValidLogFileName(string fileName)
    {
      System.Diagnostics.Debug.WriteLine(fileName, "IsValidLogFileName");
      return manager.IsValid(fileName);
    }

    internal string GetOutputFileName()
    {
      return $"{GetCurrentDateTime.ToString("yyyyMMddHHmmssfff")}.log";
    }

    internal IEnumerable<string> ReadLogFile()
    {
      return null;
    }
  }
}
