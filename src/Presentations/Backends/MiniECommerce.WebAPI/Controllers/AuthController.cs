﻿using Application.Dtos;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.LogTest;
using Application.Features.Auth.Commands.RefreshTokenCommands;
using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Commands.RevokeToken;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MiniECommerce.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly WebAPIConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
        }

        [HttpGet()]
        public async Task<IActionResult> LogTest()
        {
            var testRequest = new TestLogRequest { Message = "Log test mesajı" };
            var response = await Mediator.Send(testRequest);
            return Ok(response);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(LoggedResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IPAddress = GetIpAddress() };
            LoggedResponse result = await Mediator.Send(loginCommand);

            //if (result.RefreshToken is not null)
            //setRefreshTokenToCookie(result.RefreshToken);

            return Ok(result.ToHttpResponse());
        }

        [HttpPost()]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IPAddress = GetIpAddress() };
            RegisteredResponse result = await Mediator.Send(registerCommand);
            //setRefreshTokenToCookie(result.RefreshToken);
            return Created(uri: "", result.AccessToken);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(RefreshedTokensResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken()
        {
            RefreshTokenCommand refreshTokenCommand = new() { RefleshToken = "", IPAddress = GetIpAddress() };
            RefreshedTokensResponse result = await Mediator.Send(refreshTokenCommand);
            //setRefreshTokenToCookie(result.RefreshToken);
            return Created(uri: "", result.AccessToken);
        }

        [HttpPut()]
        [ProducesResponseType(typeof(RevokedTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RevokeToken([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] string? refreshToken)
        {
            RevokeTokenCommand revokeTokenCommand = new() { Token = refreshToken ?? "", IPAddress = GetIpAddress() };
            RevokedTokenResponse result = await Mediator.Send(revokeTokenCommand);
            return Ok(result);
        }
    }
}