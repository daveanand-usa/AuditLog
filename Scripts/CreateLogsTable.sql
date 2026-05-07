-- Run this SQL script against the MuleSoftLogging database to create the Logs table

CREATE TABLE Logs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Environment NVARCHAR(100) NOT NULL,
    Application NVARCHAR(100) NOT NULL,
    ApiName NVARCHAR(100) NOT NULL,
    CorrelationId NVARCHAR(100) NOT NULL,
    ClientIP NVARCHAR(50) NOT NULL DEFAULT '0.0.0.0',
    LogType NVARCHAR(50) NOT NULL,
    LogLevel INT NOT NULL DEFAULT 1,
    UserName NVARCHAR(100) NOT NULL,
    RequestUrl NVARCHAR(500) NOT NULL,
    RequestType NVARCHAR(20) NOT NULL,
    RequestData NVARCHAR(MAX) NOT NULL,
    Success BIT NOT NULL,
    StatusCode INT NOT NULL,
    ProcessTime NVARCHAR(50) NOT NULL,
    ResponseData NVARCHAR(MAX) NOT NULL,
    ErrorMessages NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETUTCDATE()
);
