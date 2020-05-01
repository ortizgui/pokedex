namespace pokedex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Species { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
    }
}