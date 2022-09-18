using FilmesApi.Data.DTOs.Sessao;

namespace FilmesAPI.Services
{
    public interface ISessaoService
    {
        ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto);
        ReadSessaoDto RecuperaSessoesPorId(int id);
    }
}
