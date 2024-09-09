using Application.Commands;
using Core.Entities;
using Core.Interfaces;
using Core.IRepositories;
using MediatR;

namespace Application.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Username, request.FirstName, request.LastName, request.Email);
        user.SetPassWord(_passwordHasher.HashPassword(request.Password));
        await _userRepository.AddAsync(user);
        return user.Id;
    }
}
