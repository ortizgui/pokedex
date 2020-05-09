using System;
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
        public async Task<ServiceResponse<GetPokemonDto>> GetPokemonByNumber(int pokemonNumber)
        {
            ServiceResponse<GetPokemonDto> serviceResponse = new ServiceResponse<GetPokemonDto>();

            Pokemon DbPokemon = await _context.Pokemons
                    .FirstOrDefaultAsync(p => p.Number == pokemonNumber);
            
            if(DbPokemon == null)
            {
                 
            }

            if(DbPokemon != null)
            {
                serviceResponse.Data = _mapper.Map<GetPokemonDto>(DbPokemon);
                serviceResponse.Message = $"Here all info about {DbPokemon.Name}.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Sorry, we can't find nothing about this Pokémon. Try another one.";
            }
            
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetPokemonDto>> GetPokemonByName(string pokemonName)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetPokemonDto>> AddPokemon(AddPokemonDto newPokemon)
        {
            ServiceResponse<GetPokemonDto> serviceResponse = new ServiceResponse<GetPokemonDto>();

            Pokemon pokemon = _mapper.Map<Pokemon>(newPokemon);

            await _context.Pokemons.AddAsync(pokemon);
            await _context.SaveChangesAsync();

            
            serviceResponse.Data = _mapper.Map<GetPokemonDto>(
                await _context.Pokemons
                    .FirstAsync(p => p.Number == pokemon.Number));
            serviceResponse.Message = "You find a new Pokémon! Nice job!";

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPokemonDto>> DeletePokemon(int pokemonNumber)
        {
            ServiceResponse<GetPokemonDto> serviceResponse = new ServiceResponse<GetPokemonDto>();

            try
            {
                Pokemon pokemon =
                await _context.Pokemons.FirstOrDefaultAsync(p => p.Number == pokemonNumber);

                if (pokemon != null)
                {
                    _context.Pokemons.Remove(pokemon);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetPokemonDto>(pokemon);
                    serviceResponse.Message = "Pokémon has been successfully removed from database.";
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Whops! The Pokémon #{pokemonNumber} has not been found.";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPokemonDto>>> GetAllPokemons()
        {
            ServiceResponse<List<GetPokemonDto>> serviceResponse = new ServiceResponse<List<GetPokemonDto>>();

            List<Pokemon> dbPokemons = await _context.Pokemons.ToListAsync();

            if(dbPokemons.Count == 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "You haven't registered any pokémon yet.";
                return serviceResponse;
            }

            serviceResponse.Data = (dbPokemons.Select(p => _mapper.Map<GetPokemonDto>(p))).ToList();
            serviceResponse.Message = "Here all the Pokémons you've seen so far!";

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPokemonDto>> UpdatePokemon(UpdatePokemonDto updatedPokemon)
        {
            ServiceResponse<GetPokemonDto> serviceResponse = new ServiceResponse<GetPokemonDto>();

            try
            {
                Pokemon pokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.Number == updatedPokemon.Number);

                if(pokemon == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Pokémon #{pokemon.Number} not been found.";;
                }
                else
                {
                    pokemon.Name = updatedPokemon.Name;
                    pokemon.Number = updatedPokemon.Number;
                    pokemon.Species = updatedPokemon.Species;
                    pokemon.Hp = updatedPokemon.Hp;
                    pokemon.Attack = updatedPokemon.Attack;
                    pokemon.Defense = updatedPokemon.Defense;
                    pokemon.SpAttack = updatedPokemon.SpAttack;
                    pokemon.SpDefense = updatedPokemon.SpDefense;
                    pokemon.Speed = updatedPokemon.Speed;

                    _context.Pokemons.Update(pokemon);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetPokemonDto>(pokemon);
                    serviceResponse.Message = $"Info about Pokémon #{pokemon.Number} has been updated.";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}