using CSharpPatterns.Models;
using CSharpPatterns.Conf;
using CSharpPatterns.Services;
using CSharpPatterns.Interfaces;

namespace CSharpPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Patterns");

            IUserService userService = new MySQLUserService();

            List<User> users = GetAllUsers(userService);
        }

        public static List<User> GetAllUsers(IUserService userService)
        {
            List<User> users = userService.GetAll();

            return users;
        }
    }
}