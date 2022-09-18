using AutoMapper;
using FilmesAPI.Data.DTOs.Filme;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<RequestFilmeDTO, Filme>();
            CreateMap<Filme, ResponseFilmeDTO>();

        }
    }
}
