
using Application.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class MediatRRegister
{
    public static void RegisterMediatRHandlers(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
    }
}