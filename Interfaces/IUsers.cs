namespace HelloWorld.Interfaces;

public interface IUsers
{
    public void AddUser(string name);
    public void RemoveUser(string name);
    public void ListUsers();
    public bool UserExists(string name);
}