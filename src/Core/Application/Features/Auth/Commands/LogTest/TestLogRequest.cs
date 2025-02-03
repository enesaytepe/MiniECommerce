using Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Auth.Commands.LogTest;

public class TestLogRequest : IRequest<string>, ILoggableRequest
{
    public string Message { get; set; }
}