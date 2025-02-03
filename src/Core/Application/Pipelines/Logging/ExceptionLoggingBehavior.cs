using CrossCuttingConcerns.Exceptions.Types;
using CrossCuttingConcerns.Logging;
using CrossCuttingConcerns.Logging.Serilog;
using CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Application.Pipelines.Logging;

public class ExceptionLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LoggerServiceBase _loggerServiceBase;
    private readonly bool _logBusinessExceptions;

    public ExceptionLoggingBehavior(
        LoggerServiceBase loggerServiceBase,
        IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration)
    {
        _loggerServiceBase = loggerServiceBase;
        _httpContextAccessor = httpContextAccessor;

        var logConfig = configuration
            .GetSection("SeriLogConfigurations:FileLogConfiguration")
            .Get<FileLogConfiguration>()
            ?? throw new Exception("FileLogConfiguration ayarları bulunamadı.");

        _logBusinessExceptions = logConfig.LogBusinessAndValidationExceptions;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            if ((_logBusinessExceptions && ex is BusinessException && ex is ValidationException) || (!_logBusinessExceptions && !(ex is BusinessException) && !(ex is ValidationException)))
            {
                var logDetail = new LogDetail
                {
                    MethodName = next.Method.Name,
                    Parameters = new List<LogParameter>
                    {
                        new LogParameter { Type = request.GetType().Name, Value = request }
                    },
                    User = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "?"
                };

                var exceptionInfo = new
                {
                    ExceptionMessage = ex.Message,
                    ExceptionStackTrace = ex.StackTrace
                };

                _loggerServiceBase.Error(JsonSerializer.Serialize(new { logDetail, exceptionInfo }));
            }

            throw;
        }
    }
}