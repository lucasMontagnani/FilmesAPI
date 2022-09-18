using FilmesAPI.Data.Dtos;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public interface IEnderecoService
    {
        ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto);
        List<ReadEnderecoDto> RecuperaEnderecos();
        ReadEnderecoDto RecuperaEnderecosPorId(int id);
        int AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto);
        int DeletaEndereco(int id);
    }
}
