using CSharpPatterns.Models;
using CSharpPatterns.Conf;
using CSharpPatterns.Services;

namespace CSharpPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Patterns");

            ContactService contactService = new ContactService();
            List<Contact> allContacts = contactService.GetAll();
        }
    }
}