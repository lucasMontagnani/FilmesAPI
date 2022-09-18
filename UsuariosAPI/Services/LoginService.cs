using FilmesAPI.Data.DTOs.Login;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService : ILoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager; // Classe do Identity para gerenciamento de Login
        private ITokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager,
            ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequestDTO request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }
    }
}
