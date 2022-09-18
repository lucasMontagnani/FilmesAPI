using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOs.Sessao;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService _sessaoService;
        
        public SessaoController(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.AdicionaSessao(sessaoDto);  
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = readSessaoDto.Id }, readSessaoDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDto readSessaoDto = _sessaoService.RecuperaSessoesPorId(id);
            if (readSessaoDto != null) return Ok(readSessaoDto);
            return NotFound();
        }
    }
}
