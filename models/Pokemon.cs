namespace CSharpPatterns.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        
        public List<Move> Moves { get; set; }

        public Pokemon()
        {
            this.Moves = new List<Move>();
        }
    }
}