using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
  

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readCinemaDto.Id }, readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeFilme)
        {
            List<ReadCinemaDto> readCinemaDto = _cinemaService.RecuperaCinemas(nomeFilme);
            if (readCinemaDto != null) return Ok(readCinemaDto);
            return NotFound(readCinemaDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.RecuperaCinemasPorId(id);
            if (readCinemaDto != null) return Ok(readCinemaDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            var response = _cinemaService.AtualizaCinema(id, cinemaDto);
            if (response == StatusCodes.Status200OK) return Ok($"O cinema com id = {id} foi Atualizado com sucesso.");
            return NotFound($"Não foi possivel encontrar o cinema com id = {id}.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            var response = _cinemaService.DeletaCinema(id);
            if (response == StatusCodes.Status200OK) return Ok($"O cinema com id = {id} foi Deletado com sucesso.");
            return NotFound($"Não foi possivel encontrar o cinema com id = {id}.");
        }

    }
}
