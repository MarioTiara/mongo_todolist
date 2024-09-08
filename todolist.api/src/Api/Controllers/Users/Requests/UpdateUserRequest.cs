namespace api.Controllers.Users.Requests;

public record UpdateUserRequest(
                                string Username,
                                string FirstName, 
                                string LastName, 
                                string Email, 
                                string Password);