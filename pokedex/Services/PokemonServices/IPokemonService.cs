using System.Collections.Generic;
using System.Threading.Tasks;
using pokedex.Dtos.PokemonDtos;
using pokedex.Models;

namespace pokedex.Services.PokemonServices
{
    public interface IPokemonService
    {
         Task<ServiceResponse<List<GetPokemonDto>>> GetAllPokemons();
         Task<ServiceResponse<GetPokemonDto>> AddPokemon(AddPokemonDto newPokemon);
    }
}