namespace LogAnalyzer.BLL.Interfaces
{
    public interface IWebService
    {
        string Url { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        void TransferLog(string[] analyzedLog);
    }
}
