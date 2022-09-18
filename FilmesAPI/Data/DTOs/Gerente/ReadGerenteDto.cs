using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Data.DTOs.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //public virtual List<Cinema> Cinemas { get; set; } //Necessario tipo object para o AutoMapper configurar retorno
        public virtual object Cinemas { get; set; }
    }
}
