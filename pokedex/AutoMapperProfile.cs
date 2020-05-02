using AutoMapper;
using pokedex.Dtos.PokemonDtos;
using pokedex.Models;

namespace pokedex
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pokemon, GetPokemonDto>();
            CreateMap<AddPokemonDto, Pokemon>();
            CreateMap<UpdatePokemonDto, Pokemon>();
        }
    }
}