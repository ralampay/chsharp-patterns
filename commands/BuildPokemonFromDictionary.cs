using CSharpPatterns.Models;
using System.Text.Json;

namespace CSharpPatterns.Commands
{
    public class BuildPokemonFromDictionary
    {
        // Command: To Create an instance of a Pokemon from a Dictionary structure
        // INPUT: Dictionary
        // OUTPUT: Instance of Pokemon

        private Dictionary<string, object> data;

        // 1 - Constructor that passes all inputs required
        public BuildPokemonFromDictionary(Dictionary<string, object> data)
        {
            this.data = data;

            this.CleanUp();
        }

        // 2 - Executable Method. Like its own Main method
        // Examples: Run(), Execute(), Main()
        public Pokemon Execute()
        {
            Pokemon pokemon = new Pokemon();

            pokemon.Name = (string)this.data["name"];
            pokemon.Type = (string)this.data["type"];
            pokemon.Moves = (List<Move>)this.data["moves"];

            return pokemon;
        }

        private void CleanUp()
        {
            if(this.data["name"] is JsonElement) {
                this.data["name"] = ((JsonElement)this.data["name"]).ToString();
            }

            if(this.data["type"] is JsonElement) {
                this.data["type"] = ((JsonElement)this.data["type"]).ToString();
            }

            if(this.data["moves"] is JsonElement) {

                var moveList = ((JsonElement)this.data["moves"]).EnumerateArray();

                List<Move> tempList = new List<Move>();

                while(moveList.MoveNext()) {
                    JsonElement jsonMove = moveList.Current;
                    Dictionary<string, object> temp = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonMove.ToString());
                    Console.WriteLine("Name:" + temp["name"].ToString());

                    Move m = new Move()
                    {
                        Name = temp["name"].ToString(),
                        Power = int.Parse(temp["power"].ToString())
                    };

                    tempList.Add(m);
                }

                this.data["moves"] = tempList;
            }
        }
    }
}