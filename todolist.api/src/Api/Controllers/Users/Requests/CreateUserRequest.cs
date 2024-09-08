namespace api.Controllers.Users.Requests;

public record CreateUserRequest(string Username,
                                string FirstName, 
                                string LastName, 
                                string Email, 
                                string Password);