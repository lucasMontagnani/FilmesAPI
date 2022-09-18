using FilmesAPI.Data.Dtos;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface ICinemaService
    {
        ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto);
        List<ReadCinemaDto> RecuperaCinemas(string nomeFilme);
        ReadCinemaDto RecuperaCinemasPorId(int id);
        int AtualizaCinema(int id, UpdateCinemaDto cinemaDto);
        int DeletaCinema(int id);
    }
}
