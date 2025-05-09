using System;
using HelloWorld.Classes;

namespace HelloWorld.Services;

public class UserServices
{
    private static bool NameExist(Users users, string name)
    {
        return users.UserExists(name);
    }

    private static bool BackValidation(string? name)
    {
        if (name?.ToLower() == "back")
        {
            Console.WriteLine("Going back to main menu...");
            return true;
        }
        return false;
    }

    public static void HandleAddUser(Users users)
    {
        Console.WriteLine("To go back to main menu write 'back'");

        while (true)
        {
            Console.Write("Write new user name: ");
            var name = Console.ReadLine();

            if (BackValidation(name))
            {
                return;
            }

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("User name cannot be empty. Please enter a name (or 'back'):");
                name = Console.ReadLine();
                if (BackValidation(name))
                {
                    return;
                }
            }

            if (NameExist(users, name))
            {
                Console.WriteLine("User with that name already exists. Try another name or go back");
                continue; 
            }

            users.AddUser(name);
            Console.WriteLine($"Added user with name: {name}");
            break;
        }
    }

    public static void HandleRemoveUser(Users users)
    {
        Console.WriteLine("To go back to main menu write 'back'");

        while (true)
        {
            Console.Write("Write user name to delete: ");
            var name = Console.ReadLine();

            if (BackValidation(name))
            {
                return;
            }

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("User name cannot be empty. Please enter a name (or 'back'):");
                name = Console.ReadLine();
                if (BackValidation(name))
                {
                    return;
                }
            }

            if (!NameExist(users, name))
            {
                Console.WriteLine("User not found. Try other name or go back");
                continue; // Przejdź do następnej iteracji pętli, aby ponownie zapytać o imię
            }

            users.RemoveUser(name);
            Console.WriteLine($"Attempted to remove user with name: {name}");
            break;
        }
    
    }
}