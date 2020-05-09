using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pokedex.Dtos.PokemonDtos;
using pokedex.Models;
using pokedex.Services.PokemonServices;

namespace pokedex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{pokemon}")]
        public async Task<IActionResult> GetPokemon(string pokemon)
        {
            ServiceResponse<GetPokemonDto> serviceResponse = new ServiceResponse<GetPokemonDto>();

            int number;

            if(int.TryParse(pokemon, out number))
            {
                serviceResponse = await _pokemonService.GetPokemonByNumber(number);
            }
            else
            {
                serviceResponse = await _pokemonService.GetPokemonByName(pokemon);
            }

            return Ok(serviceResponse);
        }
    }
}