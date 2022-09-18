using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Dtos
{
    public class AtivaContaRequestDto
    {
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string CodigoDeAtivacao { get; set; }
    }
}
