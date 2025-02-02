using Application.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net;

namespace MiniECommerce.WebAPI.Controllers;

public class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>(); //lazy init

    protected string? GetIpAddress()
    {
        if (Request.Headers.TryGetValue("X-Forwarded-For", out StringValues forwardedFor))
        {
            string[] ips = forwardedFor.ToString().Split(',');

            if (ips.Length > 0)
            {
                string originalIp = ips[0].Trim();

                // Validate the IP address format 
                if (System.Net.IPAddress.TryParse(originalIp, out IPAddress? parsedIp))
                {
                    // If you only want to allow IPv4 addresses
                    if (parsedIp.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return originalIp;
                    }

                    // If you also want to handle IPv6, you can add additional logic here
                    // Example:
                    // if (parsedIp.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    // {
                    //     return originalIp;
                    // }
                }
            }
        }

        // Fallback to the remote IP address if X-Forwarded-For is not present or invalid
        return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
    }

    protected long GetUserIdFromRequest() => HttpContext.User.GetUserId() ?? 0;
}