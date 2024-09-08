namespace Core.Entities;

public class User: EntityBase
{
    // private IList<Role> _roles;
    public string Username { get; private set; }
    public string FirstName {get; private set;}
    public string LastName { get; private set; }
    public  string Email { get;  private set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get;  private set; }
    public User(string username, string firstName, string lastName, string email)
    {
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = string.Empty;
        PasswordSalt = string.Empty;
        // _roles = new List<Role>();
    }

    public void Update(string username, string firstName, string lastName, string email)
    {
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }    

    // public void AddRole(Role role)
    // {
    //     _roles.Add(role);
    // }

    // public void RemoveRole(Role role)
    // {
    //     _roles.Remove(role);
    // }

    public void SetPassWord (string password, string salt)
     => (PasswordHash, PasswordSalt) = (password, salt);


}