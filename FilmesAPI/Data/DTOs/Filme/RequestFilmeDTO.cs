using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Filme
{
    public class RequestFilmeDTO
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required]
        public string Diretor { get; set; }
        [StringLength(100, ErrorMessage = "O campo genero deve ter no maximo 100 caracteres")]
        public string Genero { get; set; }
        [Required]
        [Range(1, 600, ErrorMessage = "O campo duração deve ter no minimo 1 e no maximo 600 minutos")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
