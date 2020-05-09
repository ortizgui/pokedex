using System.Collections.Generic;
using System.Threading.Tasks;
using pokedex.Dtos.PokemonDtos;
using pokedex.Models;

namespace pokedex.Services.PokemonServices
{
    public interface IPokemonService
    {
         Task<ServiceResponse<GetPokemonDto>> GetPokemonByNumber(int pokemonNumber);
         Task<ServiceResponse<GetPokemonDto>> GetPokemonByName(string pokemonName);

    }
}