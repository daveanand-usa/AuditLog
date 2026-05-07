using DoddLoggerApi.Models;
using DoddLoggerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoddLoggerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class LogController : ControllerBase
{
    private readonly ILogger<LogController> _logger;
    private readonly ILogRepository _logRepository;

    public LogController(ILogger<LogController> logger, ILogRepository logRepository)
    {
        _logger = logger;
        _logRepository = logRepository;
    }

    /// <summary>
    /// Records a log entry to the database
    /// </summary>
    /// <param name="logData">The log data containing request/response information</param>
    /// <returns>Confirmation message with correlation ID</returns>
    /// <response code="200">Log recorded successfully</response>
    /// <response code="500">Internal server error when recording log</response>
    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] LogData logData)
    {
        try
        {
            await _logRepository.InsertLogAsync(logData);
            return Ok(new { message = "Log recorded successfully", correlationId = logData.CorrelationId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inserting log for CorrelationId: {CorrelationId}", logData.CorrelationId);
            return StatusCode(500, new { message = "Error recording log", error = ex.Message });
        }
    }
}
