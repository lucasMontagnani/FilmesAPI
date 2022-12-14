using AutoMapper;
using FilmesApi.Data.DTOs.Sessao;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioInicio, opts => opts
                .MapFrom(dto =>
                dto.HorarioEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}
