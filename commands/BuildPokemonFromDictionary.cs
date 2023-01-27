using CSharpPatterns.Models;

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
    }
}