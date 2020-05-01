using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pokedex.Data;
using pokedex.Dtos.PokemonDtos;
using pokedex.Models;

namespace pokedex.Services.PokemonServices
{
    public class PokemonService : IPokemonService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public PokemonService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetPokemonDto>>> GetAllPokemons()
        {
            ServiceResponse<List<GetPokemonDto>> serviceResponse = new ServiceResponse<List<GetPokemonDto>>();

            List<Pokemon> dbPokemons = await _context.Pokemons.ToListAsync();

            if(dbPokemons.Count == 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "You haven't registered any pokemon yet.";
                return serviceResponse;
            }

            serviceResponse.Data = (dbPokemons.Select(p => _mapper.Map<GetPokemonDto>(p))).ToList();
            serviceResponse.Message = "Here all the Pokemons you've seen so far!";

            return serviceResponse;
        }
    }
}