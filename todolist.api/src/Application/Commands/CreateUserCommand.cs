using MediatR;

namespace Application.Commands;


public record CreateUserCommand(string Username, 
                string FirstName, 
                string LastName, 
                string Email, 
                string Password) : IRequest<string>;