using Infrastructure.Services;

namespace unit.test.Core;

public class PasswordHasherTests
{
    private readonly PasswordHasher _passwordHasher;
    public PasswordHasherTests()
    => _passwordHasher= new PasswordHasher();

    [Fact]
    public  void HashPassword_ShouldRetrunNotEmptyHash()
    {
        //Arrange
        var password ="mypassword";

        //Act
        var hassedPassword = _passwordHasher.HashPassword(password);

        //Assert
        Assert.NotEmpty(hassedPassword);
    }

    [Fact]
    public void VerifyPassword_ShouldReturnTrue_WhenPasswordIsValid()
    {
        //Arrange
        var password = "mypassword";
        var hassedPassword = _passwordHasher.HashPassword(password);

        //Act
        var isValid = _passwordHasher.VerifyPassword(password, hassedPassword);

        //Assert
        Assert.True(isValid);
    }

    [Fact]
    public void VerifyPassword_ShouldReturnFalse_WhenPasswordIsInvalid()
    {
        //Arrange
        var password = "mypassword";
        var hassedPassword = _passwordHasher.HashPassword(password);

        //Act
        var isValid = _passwordHasher.VerifyPassword("invalidpassword", hassedPassword);

        //Assert
        Assert.False(isValid);
    }

    [Fact]
    public void HashPassword_ShouldReturnDifferentHash_ForDifferentPasswords()
    {
        //Arrange
        var password = "mypassword";
        var password2 = "mypassword2";

        //Act
        var hassedPassword = _passwordHasher.HashPassword(password);
        var hassedPassword2 = _passwordHasher.HashPassword(password2);

        //Assert
        Assert.NotEqual(hassedPassword, hassedPassword2);
    }

}