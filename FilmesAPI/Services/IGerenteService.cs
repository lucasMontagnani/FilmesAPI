using FilmesAPI.Data.DTOs.Gerente;

namespace FilmesAPI.Services
{
    public interface IGerenteService
    {
        ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto);
        ReadGerenteDto RecuperaGerentesPorId(int id);
        int DeletaGerente(int id);
    }
}
