using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        // Referenciando a tabela Endereco por uma propriedade (para indicar que o Cinema possui UM endereco)
        //virtual para em conjunto com UseLazyLoadingProxies() conseguir carregar as propriedades das entidades relacionadas
        public virtual Endereco Endereco { get; set; }
        // Para indicar uma relacao entrea as duas entidades por Id (para indicar QUAL o endereco)
        public int EnderecoId { get; set; }
        //[JsonIgnore]
        public virtual Gerente Gerente { get; set; }
        //[JsonIgnore]
        public int GerenteId { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
