using Microsoft.EntityFrameworkCore;
using pokedex.Models;

namespace pokedex.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Pokemon> Pokemons { get; set; }
    }
}