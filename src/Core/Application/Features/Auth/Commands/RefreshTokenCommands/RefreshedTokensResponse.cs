using Application.JWT;
using Application.Responses;
using Domain.Entities;

namespace Application.Features.Auth.Commands.RefreshTokenCommands;

public class RefreshedTokensResponse : IResponse
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}
