using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace UsuariosAPI.Services
{
    public class LogoutService : ILogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result DeslogaUsuario()
        {
            Task resultadoIdentity = _signInManager.SignOutAsync();

            if (resultadoIdentity.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }
            return Result.Fail("Logout falhou");

        }
    }
}
