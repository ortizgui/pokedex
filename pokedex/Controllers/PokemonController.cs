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

        [HttpDelete("{pokemonNumber}")]
        public async Task<IActionResult> DeletePokemon(int pokemonNumber)
        {
            ServiceResponse<GetPokemonDto> response = await _pokemonService.DeletePokemon(pokemonNumber);

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePokemon(UpdatePokemonDto updatePokemon)
        {
            ServiceResponse<GetPokemonDto> response = await _pokemonService.UpdatePokemon(updatePokemon);

            if(response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}