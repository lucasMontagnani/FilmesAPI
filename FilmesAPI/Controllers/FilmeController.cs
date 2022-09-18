using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.DTOs.Filme;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeSerivice;

        public FilmeController(IFilmeService filmeSerivice)
        {
            _filmeSerivice = filmeSerivice;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] RequestFilmeDTO filmeDto)
        {
            ResponseFilmeDTO responseFilmDto = _filmeSerivice.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = responseFilmDto.Id }, responseFilmDto);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ResponseFilmeDTO>  responseFilmesDto= _filmeSerivice.RecuperaFilmes(classificacaoEtaria);
            if (responseFilmesDto != null) return Ok(responseFilmesDto); 
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            ResponseFilmeDTO filmeResponseDto = _filmeSerivice.RecuperaFilmePorId(id);
            if (filmeResponseDto != null) return Ok(filmeResponseDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] RequestFilmeDTO filmeUpdate)
        {
            var response = _filmeSerivice.AtualizaFilme(id, filmeUpdate);
            if (response == StatusCodes.Status200OK) return Ok($"O filme com id = {id} foi Atualizado com sucesso.");
            return NotFound($"Não foi possivel encontrar o filme com id = {id}.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var response = _filmeSerivice.DeletaFilme(id);
            if (response == StatusCodes.Status200OK) return Ok($"O filme com id = {id} foi Deletado com sucesso.");
            return NotFound($"Não foi possivel encontrar o filme com id = {id}.");
        }
    }
}
