using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.DTOs.Gerente;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteService _gerenteService;
        public GerenteController(IGerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.AdicionaGerente(gerenteDto);
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = readGerenteDto.Id }, readGerenteDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.RecuperaGerentesPorId(id);
            if (readGerenteDto != null) return Ok(readGerenteDto);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            var response = _gerenteService.DeletaGerente(id);
            if (response == StatusCodes.Status200OK) return Ok($"O gerente com id = {id} foi Deletado com sucesso.");
            return NotFound($"Não foi possivel encontrar o gerente com id = {id}.");
        }
    }
}
