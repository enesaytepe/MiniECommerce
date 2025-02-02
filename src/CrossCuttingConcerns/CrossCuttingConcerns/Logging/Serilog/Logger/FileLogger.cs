using CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CrossCuttingConcerns.Logging.Serilog.Logger;

public class FileLogger : LoggerServiceBase
{
    private IConfiguration _configuration;

    public FileLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        // appsettings.json dosyasından FileLogConfiguration ayarlarını al
        var logConfig = configuration.GetSection("SeriLogConfigurations:FileLogConfiguration").Get<FileLogConfiguration>()
                        ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), logConfig.FolderPath) + ".txt";

        Logger = new LoggerConfiguration().WriteTo
            .File(
                logFilePath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 31,
                fileSizeLimitBytes: 5000000,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
            )
            .CreateLogger();
    }
}