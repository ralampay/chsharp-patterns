using CSharpPatterns.Models;
using CSharpPatterns.Conf;
using CSharpPatterns.Services;
using CSharpPatterns.Interfaces;
using System.Collections.Generic;

namespace CSharpPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            {
                "firstName": "Raphael",
                "lastName": "Alampay",
            }
            */
            Dictionary<string, string> person = new Dictionary<string, string>();
            person.Add("firstName", "Raphael");
            person.Add("lastName", "Alampay");

            Console.WriteLine("Full Name: " + person["firstName"] + " " + person["lastName"]);

            /*
            {
                "favoriteFood": [
                    { "name": "Beef" }, { "name": "Chicken Nuggets" }
                ]
            }
            */
            Dictionary<string, List<Dictionary<string, string>>> favoriteFood = new Dictionary<string, List<Dictionary<string, string>>>();
            
            List<Dictionary<string, string>> listOfFood = new List<Dictionary<string, string>>();
            Dictionary<string, string> beef = new Dictionary<string, string>();
            beef.Add("name", "Beef");
            listOfFood.Add(beef);
            Dictionary<string, string> chicken = new Dictionary<string, string>();
            chicken.Add("name", "Chicken Nuggets");
            listOfFood.Add(chicken);
            
            favoriteFood.Add(
                "favoriteFood",
                listOfFood
            );

            Console.WriteLine(favoriteFood["favoriteFood"][1]["name"]); // Display Chicken Nuggets

            /*
            */
        }
    }
}