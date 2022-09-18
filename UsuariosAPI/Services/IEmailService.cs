using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public interface IEmailService
    {
        void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code);
        void Enviar(MimeMessage mensagemDeEmail);
        MimeMessage CriaCorpoDoEmail(Mensagem mensagem);
    }
}
