namespace MyCalculator.BLL.Test.Utilities
{
  using System;
  using System.Runtime.CompilerServices;

  using NUnit.Framework;

  internal class ContextWriter
  {
    public static void WriteLine(double counter, [CallerMemberName] string methodname = "")
    {
      TestContext.WriteLine($"{methodname}: {counter} - {DateTime.Now:dd-MM-yyyy HH:mm:ss.fff}");
    }

    public static void WriteLine(string classDescription, double counter, [CallerMemberName] string methodname = "")
    {
      TestContext.WriteLine($"{classDescription} - {methodname}: {counter} - {DateTime.Now:dd-MM-yyyy HH:mm:ss.fff}");
    }

    public static void WriteLine(string classDescription, [CallerMemberName] string methodname = "")
    {
      TestContext.WriteLine($"{classDescription} - {methodname}: {DateTime.Now:dd-MM-yyyy HH:mm:ss.fff}");
    }
  }
}
