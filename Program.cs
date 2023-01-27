using CSharpPatterns.Models;
using CSharpPatterns.Conf;
using CSharpPatterns.Services;
using CSharpPatterns.Interfaces;
using System.Collections.Generic;
using CSharpPatterns.Commands;
using System.Text.Json;

namespace CSharpPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // JSON Serialization
            // Native object turn into a JSON string

            Dictionary<string, string> person = new Dictionary<string, string>();
            person.Add("firstName", "Raphael");
            person.Add("lastName", "Alampay");

            string jsonPerson = JsonSerializer.Serialize(person);
            Console.WriteLine(jsonPerson);

            // using a specific case convention
            var seralizerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            Contact contact = new Contact(1, "Juan", "dela Cruz", "09770000000");

            User user = new User(1, "John", "Doe");
            user.Contacts.Add(contact);
            
            string jsonUser = JsonSerializer.Serialize<User>(user, seralizerOptions);
            Console.WriteLine(jsonUser);

            // Apply the BuildPokemonFromDictionary
            Dictionary<string, object> pData = new Dictionary<string, object>();
            pData.Add("name", "Pikachu");
            pData.Add("type", "Lightning");
            pData.Add("moves", new List<Move>());

            var cmd = new BuildPokemonFromDictionary(pData);
            Pokemon p = cmd.Execute();

            Console.WriteLine(JsonSerializer.Serialize(p, seralizerOptions));

            //Program.RunDictionaryExamples(seralizerOptions);

            // JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            // serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            // serializerOptions.WriteIndented = true;


            // JSON Deserialization
            // Given a JSON string turn into a native object


        }

        public static void RunDictionaryExamples(JsonSerializerOptions serializerOptions)
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

            Console.WriteLine(JsonSerializer.Serialize(person, serializerOptions));

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

            Console.WriteLine(JsonSerializer.Serialize(favoriteFood, serializerOptions)); // Display Chicken Nuggets

            /*
            {
                "preferences": [
                    {
                        "audio": {
                            "volume": 100,
                            "pitch": 50 
                        },
                        "video": {
                            "resolution": 5,
                            "input": 2
                        }
                    }
                ]
            }
            */
            Dictionary<string, List<Dictionary<string, Dictionary<string, int>>>> o = new Dictionary<string, List<Dictionary<string, Dictionary<string, int>>>>();

            List<Dictionary<string, Dictionary<string, int>>> prefs = new List<Dictionary<string, Dictionary<string, int>>>();

            Dictionary<string, Dictionary<string, int>> prefItems = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> audio = new Dictionary<string, int>();
            audio.Add("volume", 100);
            audio.Add("pitch", 50);

            Dictionary<string, int> video = new Dictionary<string, int>();
            video.Add("resolution", 5);
            video.Add("input", 2);

            prefItems.Add("audio", audio);
            prefItems.Add("video", video);

            prefs.Add(prefItems);

            o.Add("preferences", prefs);

            Console.WriteLine(JsonSerializer.Serialize(o, serializerOptions)); // Display 50


            /*
            {
                "firstName": "Raphael",
                "lastName": "Alampay",
                "favoriteFood": [
                    { "name": "Beef" }, { "name": "Chicken" }
                ]
            }
            */

            Dictionary<string, object> obj = new Dictionary<string, object>();
            obj.Add("firstName", "Raphael");
            obj.Add("lastName", "Alampay");

            List<object> subItems = new List<object>();

            Dictionary<string, object> beefObj = new Dictionary<string, object>();
            beefObj.Add("name", "Beef");

            Dictionary<string, object> chickenObj = new Dictionary<string, object>();
            chickenObj.Add("name", "Chicken");

            subItems.Add(beefObj);
            subItems.Add(chickenObj);

            obj.Add("favoriteFood", subItems);

            // Typecasting
            string tempFirstName = obj["firstName"].ToString(); // Explicit casting
            string tempLastName = (string)obj["lastName"];  // Implicit casting

            List<object> tempFavoriteFood = (List<object>)obj["favoriteFood"];
            Dictionary<string, object> tempBeef = (Dictionary<string, object>)tempFavoriteFood[0];

            Console.WriteLine(tempBeef["name"].ToString());

            /*
            {
                "playlist": [
                    { "name": "I can Dream About You", "genres": [ { "name": "Pop" }, { "name": "rock" } ] }
                ]
            }
            */

            Dictionary<string, object> pObj = new Dictionary<string, object>();

            List<object> pObjItems = new List<object>();

            Dictionary<string, object> pObjItem1 = new Dictionary<string, object>();

            pObjItem1.Add("name", "I can Dream About You");

            List<object> genres = new List<object>();

            Dictionary<string, string> genre1 = new Dictionary<string, string>();
            genre1.Add("name", "Pop");

            Dictionary<string, string> genre2 = new Dictionary<string, string>();
            genre2.Add("name", "rock");

            genres.Add(genre1);
            genres.Add(genre2);

            pObjItem1.Add("genres", genres);

            pObjItems.Add(pObjItem1);

            pObj.Add("playlist", pObjItems);

            List<object> playlistList = (List<object>)pObj["playlist"];
            Dictionary<string, object> firstPlaylist = (Dictionary<string, object>)(playlistList[0]);
            List<object> genresList = (List<object>)firstPlaylist["genres"];
            Dictionary<string, string> secondElement = (Dictionary<string, string>)(genresList[1]);

            // Console.WriteLine(((Dictionary<string, string>)(((List<object>)(((Dictionary<string, object>)(((List<object>)(pObj["playlist"]))[0]))["genres"]))[1]))["name"]);
            Console.WriteLine(JsonSerializer.Serialize(pObj, serializerOptions));
        }
    }
}