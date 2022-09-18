using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService : ICadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private IEmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, IEmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            if (resultadoIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new[] { usuarioIdentity.Email },
                    "Link de Ativação", usuarioIdentity.Id, encodedCode);


                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequestDto request)
        {
            var identityUser = _userManager.Users.Where(u => u.Id == request.UsuarioId).FirstOrDefault();
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao);

            if (identityResult.Result.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}
