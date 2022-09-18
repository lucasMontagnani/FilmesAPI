using FilmesAPI.Data.DTOs.Login;
using FluentResults;

namespace UsuariosAPI.Services
{
    public interface ILoginService
    {
        Result LogaUsuario(LoginRequestDTO request);
    }
}
