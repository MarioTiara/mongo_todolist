namespace Core.Entities;

public class User: EntityBase
{
    public IList<Role> Roles { get; private set; }
    public string Username { get; private set; }
    public string FirstName {get; private set;}
    public string LastName { get; private set; }
    public  string Email { get;  private set; }
    public string PasswordHash { get; private set; }
    public User(string username, string firstName, string lastName, string email)
    {
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = string.Empty;
        Roles = new List<Role>();
    }

    // public IEnumerable<Role> Roles => _roles.ToList().AsReadOnly();
    public void Update(string username, string firstName, string lastName, string email)
    {
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }    

    public void AddRole(Role role)
    {
        Roles.Add(role);
    }

    public void RemoveRole(Role role)
    {
        Roles.Remove(role);
    }

    public void SetPassWord (string password)
     => (PasswordHash) = (password);


}