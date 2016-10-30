namespace LogAnalyzer.BLL
{
  using System;
  using System.IO;
  using System.Security.Cryptography.X509Certificates;

  using Interfaces;

  public class LogAnalyzer
  {
    protected virtual DateTime GetCurrentDateTime => DateTime.Now;

    public bool ProcessLogFile(string logFilename, string outputPath)
    {
      // Just an example the real usage...
      if (!IsValidLogFileName(logFilename))
      {
        return false;
      }

      var outputFilename = GetOutputFileName();

      // And many more lines of code to come....
      return true;
    }

    public virtual bool IsExistingPath(string fullpath)
    {
      return Directory.Exists(fullpath);
    }

    internal bool IsValidLogFileName(string fileName)
    {
      return GetManager().IsValid(fileName);
    }

    internal string GetOutputFileName()
    {
      return $"{GetCurrentDateTime.ToString("yyyyMMddHHmmssfff")}.log";
    }

    protected virtual IExtensionManager GetManager()
    {
      return new FileExtensionManager();
    }
  }
}
