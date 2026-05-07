using System.ComponentModel.DataAnnotations;

namespace DoddLoggerApi.Models;

/// <summary>
/// Represents log data for tracking API requests and responses
/// </summary>
public class LogData
{
    /// <summary>
    /// Environment name (e.g., DEV, QA, PROD)
    /// </summary>
    public string Environment { get; set; } = string.Empty;

    /// <summary>
    /// Application name that generated the log
    /// </summary>
    public string Application { get; set; } = string.Empty;

    /// <summary>
    /// Name of the API being logged
    /// </summary>
    public string ApiName { get; set; } = string.Empty;

    /// <summary>
    /// Unique identifier for correlating related log entries
    /// </summary>
    public string CorrelationId { get; set; } = string.Empty;

    /// <summary>
    /// IP address of the client making the request
    /// </summary>
    public string ClientIP { get; set; } = "0.0.0.0";

    /// <summary>
    /// Type of log entry (e.g., Request, Response, Error)
    /// </summary>
    public string LogType { get; set; } = string.Empty;

    /// <summary>
    /// Log severity level
    /// </summary>
    public int LogLevel { get; set; } = 1;

    /// <summary>
    /// Username of the user making the request
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// URL of the request
    /// </summary>
    public string RequestUrl { get; set; } = string.Empty;

    /// <summary>
    /// HTTP method of the request (e.g., GET, POST)
    /// </summary>
    public string RequestType { get; set; } = string.Empty;

    /// <summary>
    /// Request body or payload
    /// </summary>
    public string RequestData { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the request was successful
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// HTTP status code of the response
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Time taken to process the request
    /// </summary>
    public string ProcessTime { get; set; } = string.Empty;

    /// <summary>
    /// Response data or payload
    /// </summary>
    public string ResponseData { get; set; } = string.Empty;

    /// <summary>
    /// Error messages if any occurred
    /// </summary>
    public string ErrorMessages { get; set; } = string.Empty;
}
