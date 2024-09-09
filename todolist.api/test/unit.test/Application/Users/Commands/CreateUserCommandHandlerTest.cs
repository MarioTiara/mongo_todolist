
using Core.Interfaces;
using Core.IRepositories;
using Moq;

using Application.Handlers;
using Application.Commands;
using Core.Entities;
using FluentAssertions;

namespace unit.test.Aplication.Users.Commands;

public class CreateUserCommandHandlerTest
{
    private readonly Mock<IUserRepository> mockUserRepository;
    private readonly Mock<IPasswordHasher> mockPasswordHasher;
    private readonly CreateUserCommandHandler _handler;

    public CreateUserCommandHandlerTest()
    {
        this.mockPasswordHasher = new Mock<IPasswordHasher>();
        this.mockUserRepository = new Mock<IUserRepository>();
        _handler = new CreateUserCommandHandler(mockUserRepository.Object, mockPasswordHasher.Object);
    }

    [Fact]
    public async Task Handle_ShouldCreatedAndReturnUserId()
    {
        //Arrange
        var command = new CreateUserCommand(
            "test",
            "test",
            "test",
            "EMAIL",
            "test");

        var expectedHashedPassword = "HASHED_PASSWORD";
        // Create a user with private setter on Id
        var user = new User(command.Username, command.FirstName, command.LastName, command.Email);

        this.mockPasswordHasher.Setup(ph => ph.HashPassword(command.Password))
            .Returns(expectedHashedPassword);

        mockUserRepository.Setup(ur => ur.AddAsync(It.IsAny<User>()))
        .Returns(Task.FromResult(user));

        //Act
        var result = await _handler.Handle(command, CancellationToken.None);

        //Assert
        result.Should().NotBe(string.Empty);
        mockPasswordHasher.Verify(ph=>ph.HashPassword(command.Password), Times.Once());
        mockUserRepository.Verify(ur=>ur.AddAsync(It.IsAny<User>()), Times.Once());

    }


}