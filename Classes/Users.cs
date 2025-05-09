using HelloWorld.Enum;
using HelloWorld.Interfaces;

namespace HelloWorld.Classes;

public class Users : IUsers
{
    private List<string> _users = new List<string>();

    public void AddUser(string name)
    {
        _users.Add(name);
    }

    public void RemoveUser(string name)
    {
        _users.Remove(name);
    }

    public void ListUsers()
    {

        if (_users.Count == 0)
        {
            Console.WriteLine("There are no users");
            return;
        }
        
        foreach (string user in _users)
        {
            Console.WriteLine($"- {user}");
        }
    }

    public bool UserExists(string user)
    {
        return _users.Contains(user);
    }
    
}