using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        //virtual para em conjunto com UseLazyLoadingProxies() conseguir carregar as propriedades das entidades relacionadas
        [JsonIgnore]// Para evitar ciclos (loop infinito) em relacionamento de entidades
        public virtual Cinema Cinema { get; set; }
    }
}
