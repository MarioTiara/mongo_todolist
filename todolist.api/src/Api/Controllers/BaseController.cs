using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace api.Controllers;


[Route("api/v{version:apiVersion}/[controller]")]
public class BaseControllerV1 : ControllerBase
{
    protected IServiceProvider Resolver => HttpContext.RequestServices;

    protected T GetService<T>()
    {
        return Resolver.GetService<T>();
    }

    protected IMediator Mediator => GetService<IMediator>();

    protected ILogger Logger => GetService<ILogger>();

}