using CrossCuttingConcerns.Logging.Serilog;
using MediatR;

namespace Application.Features.Auth.Commands.LogTest;

public class TestLogRequestHandler : IRequestHandler<TestLogRequest, string>
{
    private readonly LoggerServiceBase _loggerServiceBase;

    public TestLogRequestHandler(LoggerServiceBase loggerServiceBase)
    {
        _loggerServiceBase = loggerServiceBase;
    }

    public Task<string> Handle(TestLogRequest request, CancellationToken cancellationToken)
    {
        //_loggerServiceBase.Info(JsonSerializer.Serialize(new { LogTest = $"Test mesajı işlendi: {request.Message}" }));
        return Task.FromResult($"Test mesajı işlendi: {request.Message}");
    }
}