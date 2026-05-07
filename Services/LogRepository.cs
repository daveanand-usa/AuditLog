using DoddLoggerApi.Models;
using Microsoft.Data.SqlClient;

namespace DoddLoggerApi.Services;

public interface ILogRepository
{
    Task InsertLogAsync(LogData logData);
}

public class LogRepository : ILogRepository
{
    private readonly string _connectionString;
    private readonly ILogger<LogRepository> _logger;

    public LogRepository(IConfiguration configuration, ILogger<LogRepository> logger)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        _logger = logger;
    }

    public async Task InsertLogAsync(LogData logData)
    {
        const string sql = @"
            INSERT INTO Logs (Environment, Application, ApiName, CorrelationId, ClientIP,
                             LogType, LogLevel, UserName, RequestUrl, RequestType,
                             RequestData, Success, StatusCode, ProcessTime, ResponseData, ErrorMessages)
            VALUES (@Environment, @Application, @ApiName, @CorrelationId, @ClientIP,
                    @LogType, @LogLevel, @UserName, @RequestUrl, @RequestType,
                    @RequestData, @Success, @StatusCode, @ProcessTime, @ResponseData, @ErrorMessages)";

        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Environment", logData.Environment);
        command.Parameters.AddWithValue("@Application", logData.Application);
        command.Parameters.AddWithValue("@ApiName", logData.ApiName);
        command.Parameters.AddWithValue("@CorrelationId", logData.CorrelationId);
        command.Parameters.AddWithValue("@ClientIP", logData.ClientIP);
        command.Parameters.AddWithValue("@LogType", logData.LogType);
        command.Parameters.AddWithValue("@LogLevel", logData.LogLevel);
        command.Parameters.AddWithValue("@UserName", logData.UserName);
        command.Parameters.AddWithValue("@RequestUrl", logData.RequestUrl);
        command.Parameters.AddWithValue("@RequestType", logData.RequestType);
        command.Parameters.AddWithValue("@RequestData", logData.RequestData);
        command.Parameters.AddWithValue("@Success", logData.Success);
        command.Parameters.AddWithValue("@StatusCode", logData.StatusCode);
        command.Parameters.AddWithValue("@ProcessTime", logData.ProcessTime);
        command.Parameters.AddWithValue("@ResponseData", logData.ResponseData);
        command.Parameters.AddWithValue("@ErrorMessages", logData.ErrorMessages);

        await command.ExecuteNonQueryAsync();
        _logger.LogInformation("Log inserted successfully for CorrelationId: {CorrelationId}", logData.CorrelationId);
    }
}
