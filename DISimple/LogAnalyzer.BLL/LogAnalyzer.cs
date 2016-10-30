namespace LogAnalyzer.BLL
{
  using System;
  using System.IO;

  using Interfaces;

  public class LogAnalyzer
  {
    private readonly IExtensionManager manager;

    // private readonly IWebService webService;

    /*****************************************************************************************************************************************************************
     * To keep it simple, we're not using any DI container.
     *****************************************************************************************************************************************************************/
    public LogAnalyzer()
    {
      manager = new FileExtensionManager();
      // webService = new WebService();
    }

    /*****************************************************************************************************************************************************************
     * Normally is 'internal' invisible for the outside world. 
     * Requires in AssemblyInfo.cs: [assembly: InternalsVisibleTo("LogAnalyzer.BLL.Test")]
     *****************************************************************************************************************************************************************/
    internal LogAnalyzer(IExtensionManager manager) // , IWebService webService)
    {
      this.manager = manager;
      // this.webService = webService;
    }

    /*****************************************************************************************************************************************************************
     * By defining the property as protected internal, it is possible to override this in the unittest (with Moq).
     *****************************************************************************************************************************************************************/
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
  }
}
