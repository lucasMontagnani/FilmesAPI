using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readEnderecoDto = _enderecoService.AdicionaEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readEnderecoDto.Id }, readEnderecoDto);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            List<ReadEnderecoDto> readEnderecoDto = _enderecoService.RecuperaEnderecos();
            if (readEnderecoDto != null) return Ok(readEnderecoDto);
            return NotFound(readEnderecoDto);
            
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            ReadEnderecoDto readEnderecoDto = _enderecoService.RecuperaEnderecosPorId(id);
            if (readEnderecoDto != null) return Ok(readEnderecoDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var response = _enderecoService.AtualizaEndereco(id, enderecoDto);
            if (response == StatusCodes.Status200OK) return Ok($"O endereco com id = {id} foi Atualizado com sucesso.");
            return NotFound($"Não foi possivel encontrar o endereco com id = {id}.");

        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var response = _enderecoService.DeletaEndereco(id);
            if (response == StatusCodes.Status200OK) return Ok($"O endereco com id = {id} foi Deletado com sucesso.");
            return NotFound($"Não foi possivel encontrar o endereco com id = {id}.");
        }

    }
}