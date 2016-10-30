namespace LogAnalyzer.BLL.Test.Builders
{
  using Interfaces;

  using Moq;

  internal class LogAnalyzerBuilder
  {
    private IExtensionManager extensionManager;
    private IWebService webService;

    public LogAnalyzerBuilder()
    {
      extensionManager = new Mock<IExtensionManager>().Object;
      webService = new Mock<IWebService>().Object;
    }

    /*
    /// <summary>
    /// By implementing the implicit operator saves a explicit call of the .Build method.
    /// </summary>
    /// <param name="builder">De instantie die we willen gebruiken.</param>
    public static implicit operator LogAnalyzer(LogAnalyzerBuilder builder)
    {
        return builder.Build();
    }
    */

    public LogAnalyzerBuilder WithExtensionManager(IExtensionManager manager)
    {
      extensionManager = manager;
      return this;
    }

    public LogAnalyzerBuilder WithService(IWebService service)
    {
      webService = service;
      return this;
    }

    /// <summary>
    /// Voor integratie tests return the real object
    /// </summary>
    /// <returns>The builder with the real FileExtensionManager</returns>
    public LogAnalyzerBuilder WithRealExtensionManager()
    {
      extensionManager = new FileExtensionManager();
      return this;
    }

    public LogAnalyzer Build()
    {
      return new LogAnalyzer(extensionManager); // , webService
    }
  }
}
