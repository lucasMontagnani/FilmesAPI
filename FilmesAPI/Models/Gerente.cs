using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        // A referencia será uma lista pois a relação é 1:N (nenhum, um ou muitos)
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
