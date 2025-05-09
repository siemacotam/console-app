using System;
using HelloWorld.Classes;
using HelloWorld.Enum;
using HelloWorld.Services;
using Math = HelloWorld.Classes.Math;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Log("Application is starting...");
            
            Cities cities = new Cities();
            Users users = new Users();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("To check all commands write _options");
            Console.WriteLine("If You want to go back in any method or step write back");
            Console.WriteLine("To end program write exit on main menu");


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("What you want to do? : ");
                var input = Console.ReadLine();
                
                if (input?.ToLower() == "exit")
                {
                    break;
                } else if (input?.ToLower() == "_options")
                {
                   LogOptions();
                } else if (input?.ToLower() == "adduser")
                {
                    UserServices.HandleAddUser(users);
                } else if (input?.ToLower() == "listusers")
                {
                    users.ListUsers();
                } else if (input?.ToLower() == "removeuser")
                {
                    UserServices.HandleRemoveUser(users);
                } else if (input?.ToLower() == "addition")
                {
                    Math.PerformMathOperation(Math.Addition);
                }
                else if (input?.ToLower() == "subtraction")
                {
                    Math.PerformMathOperation(Math.Subtraction);
                }
                else if (input?.ToLower() == "multiplication")
                {
                    Math.PerformMathOperation(Math.Multiplication);
                }
                else if (input?.ToLower() == "division")
                {
                    Math.PerformMathOperation(Math.Division);
                }
                else 
                {
                    Console.WriteLine($"There is no such option: {input}");
                }
            }
            Log("Application is ending...");
        }

        static void LogOptions()
        {
            // Users
            Console.WriteLine(Options.Users.ToString());
            foreach (UsersOptions option in System.Enum.GetValues(typeof(Options)))
            {
                Console.WriteLine($"- {option}");
            }
                    
            // Math
            Console.WriteLine(Options.Math.ToString());
            foreach (MathOptions option in System.Enum.GetValues(typeof(Options)))
            {
                Console.WriteLine($"- {option}");
            }
                    
            // Cities
            Console.WriteLine(Options.Cities.ToString());
            foreach (CitiesDBOptions option in System.Enum.GetValues(typeof(Options)))
            {
                Console.WriteLine($"- {option}");
            }
        }
        static void Log(string message)
        {
            Console.WriteLine($"[LOG - {DateTime.Now}] {message}");
        }
    }
}


