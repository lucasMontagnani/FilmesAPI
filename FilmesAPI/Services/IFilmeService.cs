using FilmesAPI.Data.DTOs.Filme;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface IFilmeService
    {
        ResponseFilmeDTO AdicionaFilme(RequestFilmeDTO filmeDto);
        List<ResponseFilmeDTO> RecuperaFilmes(int? classificacaoEtaria);
        ResponseFilmeDTO RecuperaFilmePorId(int id);
        int AtualizaFilme(int id, RequestFilmeDTO filmeUpdate);
        int DeletaFilme(int id);
    }
}
