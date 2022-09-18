using FluentResults;
using UsuariosAPI.Data.Dtos;

namespace UsuariosAPI.Services
{
    public interface ICadastroService
    {
        Result CadastraUsuario(CreateUsuarioDto createDto);
        Result AtivaContaUsuario(AtivaContaRequestDto request);
    }
}
