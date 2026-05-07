namespace DoddLoggerApi.Models;

public class LogData
{
    public string Environment { get; set; } = string.Empty;
    public string Application { get; set; } = string.Empty;
    public string ApiName { get; set; } = string.Empty;
    public string CorrelationId { get; set; } = string.Empty;
    public string ClientIP { get; set; } = "0.0.0.0";
    public string LogType { get; set; } = string.Empty;
    public int LogLevel { get; set; } = 1;
    public string UserName { get; set; } = string.Empty;
    public string RequestUrl { get; set; } = string.Empty;
    public string RequestType { get; set; } = string.Empty;
    public string RequestData { get; set; } = string.Empty;
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string ProcessTime { get; set; } = string.Empty;
    public string ResponseData { get; set; } = string.Empty;
    public string ErrorMessages { get; set; } = string.Empty;
}
