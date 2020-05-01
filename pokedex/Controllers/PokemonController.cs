using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetTask()
        {
            return Ok(await _pokemonService.GetAllPokemons());
        }

    }
}