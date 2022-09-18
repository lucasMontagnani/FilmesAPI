using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public interface ITokenService
    {
        Token CreateToken(IdentityUser<int> usuario);
    }
}
