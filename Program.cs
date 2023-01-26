﻿using CSharpPatterns.Models;
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

            Console.WriteLine(o["preferences"][0]["audio"]["pitch"]); // Display 50
        }
    }
}