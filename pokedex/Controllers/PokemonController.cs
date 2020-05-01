using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pokedex.Dtos.PokemonDtos;
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPokemon()
        {
            return Ok(await _pokemonService.GetAllPokemons());
        }

        [HttpPost]
        public async Task<IActionResult> AddPokemon(AddPokemonDto newPokemon)
        {
            return Ok(await _pokemonService.AddPokemon(newPokemon));
        }

    }
}